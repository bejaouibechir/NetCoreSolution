//#define version1
#define version2
using System;
using System.Runtime.InteropServices;

namespace InjectionServiceApp
{
    internal class Program
    {
        //Inverse of control Container
        static void Main(string[] args)
        {
#if version1       
            IModuleExterne moduleExterne = new ModuleExterne();
#endif

#if version2
            IModuleExterne moduleExterne = new ModuleExterne2();
#endif


            Application application = new Application(moduleExterne);
            application.fonctionalité();
        }
    }

    public class ModuleExterne2 : IModuleExterne
    {
        public void fonctonalité()
            => Console.WriteLine("Je suis une extra fonctionalité version 2");
    }


    public class ModuleExterne : IModuleExterne
    {
        public void fonctonalité()
            => Console.WriteLine("Je suis une extra fonctionalité");
    }

    //Inverse of control
    public class Application
    {
        private readonly IModuleExterne _moduleExterne;

        public Application(IModuleExterne moduleExterne)
        {
            _moduleExterne = moduleExterne;
        }


        public void fonctionalité()
        {
            _moduleExterne.fonctonalité();
        }

    }
}
