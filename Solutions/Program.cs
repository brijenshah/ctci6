using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Ch_01.Arrays_and_Strings;
using Core;

namespace Solutions
{
    class Program
    {
        public static readonly IDictionary<string, IQuestion> Map = new Dictionary<string, IQuestion>();

        static void Main(string[] args)
        {
            LoadQuestionCatalog();
            
            Console.Write("Question Code: ");
            var code = Console.ReadLine();

            if (Map.ContainsKey(code))
            {
                var question = Map[code];
                Console.WriteLine($"{Environment.NewLine}Executing {question.Metadata().Description}...{Environment.NewLine}");
                question.Run();
            }
            else
            {
                Console.WriteLine($"Code: {code} not found. Please enter in CH01.Q01 format...");
            }

            Console.Write($"{Environment.NewLine}Please [Enter] to exist...");
            Console.ReadLine();

        }

        private static void LoadQuestionCatalog()
        {
            var assemblies = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.TopDirectoryOnly)
                                .Where(filePath => Path.GetFileName(filePath).StartsWith("Ch"))
                                .Select(Assembly.LoadFrom);

            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(assemblies.ToArray())
                .Where(t => typeof(IQuestion).IsAssignableFrom(t))
                .InstancePerLifetimeScope()
                .AsImplementedInterfaces();

            var container = builder.Build();

            var questions = container.Resolve<IEnumerable<IQuestion>>();
            foreach (var question in questions)
            {
                Map.Add(question.Metadata().Code, question);
            }
        }
    }
}
