using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Draughts
{
    public class LoaderAssembly
    {
        public AppDomain AppDomain { get; set; }
        public Assembly Assembly { get; set; }
        public Type T { get; set; }
        public object Instance { get; set; }

        public readonly string DomainName = "LoaderAssembly";


        public void LoadAssembly(string path)
        {
            Debug.WriteLine(DateTime.Now.ToLongTimeString() + " Creates app domain and defines assembly.");
            AppDomain = AppDomain.CreateDomain(DomainName);
            Assembly asm = Assembly.LoadFrom(path);
            T = asm.GetType("AssemblyLibrary.Globchange");
            Instance = Activator.CreateInstance(T);
        }



        public bool AssemblyCheck(string path)
        {
            Debug.WriteLine(DateTime.Now.ToLongTimeString() + " Checks if assembly with reflection is OK .");
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += AssemblyReflectionHelper;
            Assembly asm = Assembly.ReflectionOnlyLoadFrom(path);
            var loaderType = asm.GetType("AssemblyLibrary.Globchange");

            if (loaderType == null)
            {
                return false;
            }
            MethodInfo changeCulture = loaderType.GetMethod("ChangeCulture");

            if (changeCulture == null)
            {
                return false;
            }

            if (changeCulture.GetParameters().Length > 1 ||
                changeCulture.GetParameters().FirstOrDefault()?.ParameterType != typeof(string))
            {
                return false;
            }

            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve -= AssemblyReflectionHelper;
            return true;
        }
        public Assembly AssemblyReflectionHelper(object o, ResolveEventArgs args)
        {
            return Assembly.ReflectionOnlyLoad(args.Name);
        }
        public void LoadMethodChangeCulture(string culture)
        {
            T.GetMethod("ChangeCulture").Invoke(Instance, new object[] { culture });
        }

    }
}
