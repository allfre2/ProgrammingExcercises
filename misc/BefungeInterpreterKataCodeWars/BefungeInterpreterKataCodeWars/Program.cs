using System;
using System.Linq;

namespace BefungeInterpreterKataCodeWars
{
    class Program
    {
        static string[][] tests = 
        {
       //     new string[] { ">987v>.v      \nv456<  :\n>321 ^ _@", "123456789" },
       //     new string[] { ">              v\nv  ,,,,,\"Hello\"<\n>48*,          v\nv,,,,,,\"World!\"<\n>25*,@", "Hello World!\n" },
       //     new string[] { ">25*\"!dlrow ,olleH\":v\n                 v:,_@\n                 >  ^", "Hello, world!\n"},
            new string[] { "01->1# +# :# 0# g# ,# :# 5# 8# *# 4# +# -# _@", "Quine"},
            new string[] {"0 v \n \"<@_ #! #: #,<*2-1*92,*84,*25,+*92*4*55.0", "Quine"},
            new string[] { "<>>#;>:#,_@;\"Hello, world!\"", "Hello, world!"},
            new string[] { ";Hello, world!; >00ga6*1-->#@_1>:#<>#<0#<g#<:#<a#<6#<*#<1#<-#<-#<>#+>#1>#,_$$@", "Hello, world!"},
            new string[] { "5 :>>#;1-:48*+01p*01g48*-#;1#+-#1:#<_$.@", "120"},
            new string[] { "v ;11111111;\n>>>>>>>>>>>>>>>a0g68*-90g68*-2*+80g68*-4*+70g68*-8*+v\n@.+***288-*86g03+**88-*86g04+**84-*86g05+**44-*86g06<", "255"},
            new string[] {
 @"5>:1-:v v *_$.@ 
 ^    _$>\:^", "?"},
        };

        static void Main(string[] args)
        {
            var befunge = new BefungeInterpreterOriginal();
#if DEBUG
            Console.WriteLine("Running Test Cases ...");
            foreach(var testcase in tests)
            {
                Console.WriteLine($"--- Running Code: \n{testcase[0]}\n");
                var output = befunge.Interpret(testcase[0]);
                Console.WriteLine($"--- Output: \n\n{output}\n--- "+(output == testcase[1] ? "Success" : "Fail"));
                Console.WriteLine($"--- Expected: \n{testcase[1]}\n");
                Console.WriteLine($"--- Stack Dump: {string.Concat(befunge.StackDump().Select(i=>i.ToString()))}");
                Console.ReadKey();
            }
#else
            foreach (var code in args)
            {
                befunge.Interpret(code);
            }
#endif
        }
    }
}
