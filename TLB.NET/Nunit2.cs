using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NAnt.Contrib.Types;
using NAnt.Core;
using NAnt.Core.Attributes;
using NAnt.Core.Types;
using NAnt.NUnit2.Tasks;
using NAnt.NUnit2.Types;

namespace NAnt.NUnit2.Tasks
{
    [TaskName("tlbnunit2")]
    public class LoadBalancedNunit2Task : NUnit2Task
    {

        protected override void ExecuteTask()
        {
            var nUnit2TestCollection = base.Tests;
            var stringCollection = nUnit2TestCollection[0].Assemblies.FileNames;
            var assemblyNames = new StringBuilder();
            foreach (var str in stringCollection)
            {
                assemblyNames.AppendLine(new FileInfo(str).Name);
            }
            Console.Out.WriteLine(assemblyNames);
            throw new NotImplementedException("Back to tlbnunit2");
        }
        
    }
}