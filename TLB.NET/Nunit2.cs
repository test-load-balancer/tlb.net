using System;
using NAnt.Contrib.Types;
using NAnt.Core;
using NAnt.Core.Attributes;
using NAnt.Core.Types;
using NAnt.NUnit2.Tasks;
using NAnt.NUnit2.Types;

namespace NAnt.NUnit2.Tasks
{
    [TaskName("tlbnunit2")]
    public class LoadBalancedNunit2 : NUnit2Task
    {
        private LoadBalancedFileSet _loadBalancedFileSet;
        private LoadBalancedNUnit2TestCollection _tests = new LoadBalancedNUnit2TestCollection();

        [BuildElementArray("test")]
        public LoadBalancedNUnit2TestCollection Tests
        {
            get { return _tests; }
        }
        
        protected override void ExecuteTask()
        {
            throw new NotImplementedException();
        }
        
    }
}