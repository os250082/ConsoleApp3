using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotNet.GitHubAction
{
    public class TestAssemblyLoader
    {
        Assembly AssemblyToLoad;
        public TestAssemblyLoader(string assemblyToLoad)
        {
            AssemblyToLoad = Assembly.LoadFrom(assemblyToLoad);
        }
       
        public IEnumerable<Type> GetTestsClasses()
        {
            return AssemblyToLoad.GetTypes()
                .Where(type => type.GetCustomAttributes
                (typeof(TestClassAttribute), true).Length > 0);
        }

        public string GetAssemblyName()
        {
            return AssemblyToLoad.ManifestModule.Name;
        }
    }
}
