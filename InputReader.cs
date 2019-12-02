using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AdventOfCode
{
    public abstract class InputReader : IAoCMainFile
    {
        protected string InputFileName = "input";

        private const string ResourceFolder = "Resources";

        protected string Path;

        protected string ReadWholeFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(GetPath()))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return string.Empty;
            }
        }

        protected List<string> ReadLines()
        {
            try
            {
                List<string> output = new List<string>();
                using (StreamReader sr = new StreamReader(GetPath()))
                {
                    while (!sr.EndOfStream)
                    {
                        output.Add(sr.ReadLine());
                    }
                    return output;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return new List<string>();
            }
        }

        private string GetPath()
        {
            return ConcatPaths(ResourceFolder, Path, InputFileName + ".txt");
        }

        protected string ConcatPaths(params string[] paths)
        {
            return string.Join("\\", paths);
        }

        public abstract void RunTask();
    }
}
