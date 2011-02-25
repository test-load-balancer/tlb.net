using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Text;
using NAnt.Core.Attributes;
using NAnt.NUnit2.Types;

namespace NAnt.NUnit2.Tasks
{
    [TaskName("tlbnunit2")]
    public class LoadBalancedNunit2Task : NUnit2Task
    {
        protected override void ExecuteTask()
        {
            NUnit2TestCollection nUnit2TestCollection = base.Tests;
            StringCollection testAssemblyFileNames = nUnit2TestCollection[0].Assemblies.FileNames;
            var types = new List<String>();
            foreach (var assemblyName in testAssemblyFileNames)
            {
                var testFile = new FileInfo(assemblyName);
                Assembly testAssembly =  Assembly.LoadFrom(testFile.FullName);
                foreach (var type in testAssembly.GetTypes())
                {
                    if (type.GetType().Name.Equals("RuntimeType"))
                    {
                        types.Add(type.FullName);
                    }
                }
            }
            var response = new BalancerClient().PostRequestToBalancer(toPostString(types));
            Console.Out.WriteLine(response);
        }

        private string toPostString(List<string> types)
        {
            var postValue = new StringBuilder();
            foreach (var type in types)
            {
                postValue.Append(type).Append("\n");
            }
            return postValue.ToString();
        }
    }
}