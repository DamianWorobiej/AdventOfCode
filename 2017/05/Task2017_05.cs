using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode._2017._05
{
    class Task2017_05 : InputReader
    {
        protected new string Path = @"2017\05";

        public Task2017_05()
        {
            base.Path = Path;
        }

        public override void RunTask()
        {
            Console.WriteLine(ReadWholeFile());
        }
    }
}
