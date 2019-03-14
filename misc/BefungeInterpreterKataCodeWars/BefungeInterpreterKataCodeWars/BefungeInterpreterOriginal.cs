using System;
using System.Collections.Generic;
using System.Linq;

namespace BefungeInterpreterKataCodeWars
{
    // Just Befunge 93, and some 98.
    class BefungeInterpreterOriginal
    {bool debugg;
        void init(string _input)
        {
            debugg = true;
            output = "";
            stack = new int[stackSize];
            sp = 0;
            ip = 0;
            x = -1; y = 0;
            dx = 1; dy = 0;

            strmode = false;
            skipmode = false;
            halt = false;

            input = _input;
            w = 0; h = 1; int tmp = 0;
            for (int i = 0; i < input.Length; ++i)
            {
                ++tmp;
                if (input[i] == '\n')
                {
                    w = tmp > w ? tmp : w;
                    tmp = 0;
                    ++h;
                }
            }
            w = tmp > w ? tmp : w;

            // Padding
            input = string.Concat(input.Split("\n").Select(s => (s.Length < w ? s + new string(' ', w - s.Length) : s) + "\n"));
        }

        public string Interpret(string _input)
        {
            init(_input);
            while (true)
            {
                if (debugg)
                {
                    Console.WriteLine("\n" + input + "\n");
                    Console.WriteLine($"> op: ({input[ip]}) ip: {ip} (x = {x}, y = {y}) (dx = {dx}, dy = {dy}) size: {w} x {h}, strmode: {strmode} (_x = {_x}, _y = {_y})\n  Stack (sp = {sp}): {string.Concat(StackDump().Select(i => i.ToString() + ","))} \n   ({string.Concat(StackDump().Select(i => (char)i))}) \n  Output: {output}\n");
                    string key = Console.ReadKey().Key.ToString();
                    if ( key == "Q") { break; }
                    if ( key == "S") { debugg = false; }
                    Console.Clear();
                }
                exec(nextOp()); // IndexOutOfBounds
                if (halt) break;
            }

            return output;
        }

        void exec(char op)
        {

            if (op == '"') { strmode = !strmode; return; }
            if (op == ';') { skipmode = !skipmode; return; }
            if (strmode) { stack[sp++] = op; return; }
            if(skipmode) { return; }

            if (char.IsDigit(op)) { stack[sp++] = (int)(op - '0'); } 
            else
                switch (op)
                {
                    case '+':
                        if (sp > 1) { stack[sp - 2] = stack[sp - 1] + stack[sp - 2]; --sp; }
                        break;

                    case '-':
                        if (sp > 1) { stack[sp - 2] = stack[sp - 2] - stack[sp - 1]; --sp; }
                        break;

                    case '*':
                        if (sp > 1) { stack[sp - 2] = stack[sp - 1] * stack[sp - 2]; --sp; }
                        break;

                    case '/':
                        if (sp > 1) { stack[sp - 2] = stack[sp - 1] != 0 ? stack[sp - 2] / stack[sp - 1] : 0; --sp; }
                        break;

                    case '%':
                        if (sp > 1) { stack[sp - 2] = stack[sp - 1] != 0 ? stack[sp - 2] % stack[sp - 1] : 0; --sp; }
                        break;

                    case '!':
                        if (sp > 0) stack[sp - 1] = stack[sp - 1] == 0 ? 1 : 0;
                        break;

                    case '`':
                        if (sp > 1) { stack[sp - 2] = stack[sp - 2] > stack[sp - 1] ? 1 : 0; --sp; }
                        break;

                    case '>':
                        dx = 1; dy = 0;
                        break;

                    case '<':
                        dx = -1; dy = 0;
                        break;

                    case 'v':
                        dx = 0; dy = 1;
                        break;

                    case '^':
                        dx = 0; dy = -1;
                        break;

                    case '?':
                        switch (new Random().Next(0, 4))
                        {
                            case 0: dx = 1; dy = 0; break;
                            case 1: dx = 0; dy = 1; break;
                            case 2: dx = -1; dy = 0; break;
                            case 3: dx = 0; dy = -1; break;
                        }
                        break;

                    case '_':
                        dy = 0;
                        if (sp <= 0 || stack[--sp] == 0) dx = 1;
                        else dx = -1;
                        break;

                    case '|':
                        dx = 0;
                        if (sp <= 0 || stack[--sp] == 0) dy = 1;
                        else dy = -1;
                        break;

                    case ':':
                        stack[sp] = sp < 1 ? 0 : stack[sp - 1]; ++sp;
                        break;

                    case '\\':
                        if (sp > 0)
                        {
                            if (sp > 1)
                            {
                                int tmp = stack[sp - 1];
                                stack[sp - 1] = stack[sp - 2];
                                stack[sp - 2] = tmp;
                            }
                            else stack[sp - 1] = 0;
                        }
                        break;

                    case '$':
                        if (sp > 0) --sp;
                        break;

                    case '.':
                        if (sp > 0) output += stack[--sp].ToString();
                        break;

                    case ',':
                        if (sp > 0) output += (char)stack[--sp];
                        break;

                    case '#':
                        nextOp();
                        break;

                    case 'p':
                        if (sp >= 3) { _y = stack[sp - 1]; _x = stack[sp - 2]; V = stack[sp - 3]; sp -= 3; put(_x, _y, (char)V); }
                        break;

                    case 'g':
                        if (sp >= 2) { _y = stack[sp - 1]; _x = stack[sp - 2]; stack[sp - 2] = input[index(_x, _y)]; sp -= 1; }
                        break;

                    case '&':
                        int.TryParse(Console.ReadLine(), out stack[sp++]);
                        break;

                    case '~':
                        char c;
                        char.TryParse(Console.ReadLine(), out c);
                        break;
                    
                    // TODO: a-f, psh hex integer 10 - 15
                    // TODO: ]  [ turn right, turn left

                    case '=': // TODO: Execute
                        break;

                    case '@':
                        halt = true;
                        break;

                    default:
                        break;
                }
        }

        char nextOp()
        {
            x += dx; y += dy;

            if (dx != 0)
            {
                if (x < 0) x = w - 1;
                if (x >= w) x = 0;
            }

            if (dy != 0)
            {
                if (y < 0) y = h;
                if (y >= h) y = 0;
            }

            ip = index();
            if (ip < input.Length)
                return input[ip];
            else halt = true;
            return ' ';
        }

        bool put(int x, int y, char V)
        {
            if (x > -1 && x < w && y > -1 && y < h)
            {
                var chars = input.ToCharArray();
                chars[index(x, y)] = V;
                input = new string(chars);
                return true;
            }
            else return false;
        }

        char get(int x, int y) => input[index(x, y)];

        int index() => index(x, y);

        int index(int x, int y) => ((y * (w + 1)) + x);

        string input, output;

        static readonly int stackSize = 1 << 24; // "UnBounded"
        int[] stack;
        int sp,
              ip,
              w, h,
              x, y,
              dx, dy;

        bool strmode,

             skipmode,

             halt;

        int _y, _x, V;

        public IEnumerable<int> StackDump() => stack.Take(sp);
    }
}
