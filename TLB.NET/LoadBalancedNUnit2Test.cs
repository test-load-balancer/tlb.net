using System;
using NAnt.Core.Attributes;
using NAnt.Core.Types;
using NAnt.NUnit2.Types;
using NAnt.DotNet.Types;

namespace NAnt.NUnit2.Types
{
    [ElementName("test")]
    public class LoadBalancedNUnit2Test : NUnit2Test
    {
        private AssemblyFileSet _assemblies = new AssemblyFileSet();

        [BuildElement("assemblies")]
        public AssemblyFileSet Assemblies
        {
            get
            {
                _assemblies.Scan();
                foreach (var fileName in _assemblies.FileNames)
                {
                    Console.Out.WriteLine(">>>" + fileName);
                }
                return _assemblies;
            }
            set { _assemblies = value; }
        }
    }
}