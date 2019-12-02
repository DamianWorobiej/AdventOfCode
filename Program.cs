using System;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Type taskType = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .FirstOrDefault(t => t.Name == "Task" + args[0]);
            IAoCMainFile task = (IAoCMainFile)Activator.CreateInstance(taskType);
            task.RunTask();
            Console.ReadLine();
        }
    }
}
