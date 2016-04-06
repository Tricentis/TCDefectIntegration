using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace TCDefectIntegration {

    class Program {

        private const string ArgCreateDefect = "create";
        private const string ArgOpenDefect = "open";
        private const string ArgGetStatesDefect = "getstates";
        private const string ArgGetDefectIdInfo = "getdefectidinfo";
        
        static int ShowUsage() {
            Console.WriteLine("Usage:");
            Console.WriteLine(ArgProgName + " " + ArgCreateDefect + " <dataFilePath> OR");
            Console.WriteLine(ArgProgName + " " + ArgOpenDefect + " <dataFilePath> OR");
            Console.WriteLine(ArgProgName + " " + ArgGetStatesDefect + " <dataFilePath> OR");
            Console.WriteLine(ArgProgName + " " + ArgGetDefectIdInfo + " <dataFilePath>");
#if DEBUG
            Console.Write("Press <ENTER> to continue > ");
            Console.Out.Flush();
            Console.ReadLine();
#endif
            return -1;
        }

        private static string ArgProgName {
            get {
                Assembly thisAssembly = Assembly.GetExecutingAssembly();
                return thisAssembly.ManifestModule.Name;
            }
        }

        static int Main(string[] args) {

            IntegrationManager integrationManager = new IntegrationManager();

            for (int i = 0; i < args.Length; i++) {
                switch (args[i].ToLower()) {
                    case ArgCreateDefect:
                        if (i + 1 < args.Length) {
                            i++;
                            return integrationManager.CreateDefect(args[i]);
                        } else {
                            return ShowUsage();
                        }
                    case ArgOpenDefect:
                        if (i + 1 < args.Length) {
                            i++;
                            return integrationManager.OpenDefect(args[i]);
                        } else {
                            return ShowUsage();
                        }
                    case ArgGetStatesDefect:
                        if (i + 1 < args.Length) {
                            i++;
                            return integrationManager.GetStatesForDefects(args[i]);
                        } else {
                            return ShowUsage();
                        }
                    case ArgGetDefectIdInfo:
                        if (i + 1 < args.Length) {
                            i++;
                            return integrationManager.GetInfosForDefects(args[i]);
                        } else {
                            return ShowUsage();
                        }
                    default:
                        return ShowUsage();
                }
            }

            return ShowUsage();
        }

    }
}
