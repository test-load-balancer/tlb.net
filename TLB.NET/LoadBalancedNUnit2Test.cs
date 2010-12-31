using NAnt.Core.Attributes;
using NAnt.Core.Types;
using NAnt.NUnit2.Types;
using NAnt.DotNet.Types;

namespace NAnt.NUnit2.Types
{
    [ElementName("test")]
    public class LoadBalancedNUnit2Test : NUnit2Test
    {
        private LoadBalancedFileSet _assemblies = new LoadBalancedFileSet();

        [BuildElement("assemblies")]
        public LoadBalancedFileSet Assemblies
        {
            get { return _assemblies; }
            set { _assemblies = value; }
        }
    }
}