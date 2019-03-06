﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BefungeInterpreterKataCodeWars
{
    class BefungeInterpreter
    {
        void init(string _input)
        {
            output = "";
            stack = new int[stackSize];
            sp = 0;
            ip = 0;
            x = 0; y = 0;
            dx = 1; dy = 0;
            
            strmode = false;
            halt = false;

            input = _input;
            w = 0; h = 1; int tmp = 0;
            for(int i = 0; i < input.Length; ++i)
            {
                ++tmp;
                if (input[i] == '\n')
                {
                    w = tmp > w ? tmp : w;
                    tmp = 0;
                    ++h;
                }
            }

            // Padding
            input = string.Concat(input.Split("\n").Select(s=> (s.Length < w ? s+new string(' ', w-s.Length):s)+"\n"));
        }

        public string Interpret(string _input)
        {
            init(_input);
            while (true)
            {
                exec(nextOp());
                if (halt) break;
            }

            return output;
        }

        void exec(char op)
        {
            int _y, _x, V;

            if (op == '"') { strmode = !strmode; return; }
            if (strmode) { stack[sp++] = op; return; }

            if (char.IsDigit(op)) stack[sp++] = op - '0';
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
                    if(sp > 0) stack[sp - 1] = stack[sp - 1] == 0 ? 1 : 0;
                break;

                case '`':
                    if (sp > 1) { stack[sp - 2] = stack[sp - 2] >  stack[sp - 1] ? 1 : 0; --sp; }
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
                    switch(new Random().Next(0,4))
                    {
                        case 0: dx = 1;  dy = 0;  break;
                        case 1: dx = 0;  dy = 1;  break;
                        case 2: dx = -1; dy = 0;  break;
                        case 3: dx = 0;  dy = -1; break;
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
                    if(sp > 0)
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
                    if(sp > 0) --sp;
                break;

                case '.':
                    if(sp > 0) output += stack[--sp].ToString();
                break;

                case ',':
                    if (sp > 0) output += (char)stack[--sp];
                break;

                case '#':
                    nextOp();
                break;

                case 'p':
                    if(sp >= 3) { _y = stack[sp - 1]; _x = stack[sp - 2]; V = stack[sp - 3]; sp -= 3; put(_x,_y,(char)V); }
                break;

                case 'g':
                    if (sp >= 2) { _y = stack[sp - 1]; _x = stack[sp - 2]; stack[sp - 2] = input[index(_x, _y)]; sp -= 1; }
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

            if(dx != 0)
            {
                if (x < 0) x = w - 1;
                if (x >= w) x = 0;
            }

            if(dy != 0)
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

        int index() => index(x,y);

        int index(int x, int y) => ((y * (w+1)) + x);

        string input, output;

        static readonly int stackSize = 1 << 24; // "UnBounded"
        int[] stack;
        int   sp,
              ip,
              w, h,
              x, y,
              dx, dy;

        bool strmode,

             halt;

        public IEnumerable<int> StackDump() => stack.Take(sp);
    }
}
