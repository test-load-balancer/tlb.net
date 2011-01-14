using NUnit.Framework;
using TLBNETTasks;

namespace TLB.NET
{
    public class BalancerClientTest
    {
        private BalancerClient _client = new BalancerClient("10.4.4.74", 3001);

        [Test]
        public void ShouldReturnAListOfPrunedFilesFromBalancer()
        {
            var fileList = new[] {"foo/baz", "43252435/fadlskkfjdsal","a/b"};
            Assert.AreEqual(new [] {"foo/baz"},_client.GetSuiteFilesFromIncludes(fileList));
        }

        [Test]
        public void ShouldPostResultTimesToBalancer()
        {
            var fileListWithTimes = new[] {"foo/baz: 100", "a/b: 445"};
            var postSuiteTimes = _client.PostSuiteTimes(fileListWithTimes); 
            Assert.AreEqual("", postSuiteTimes);
        }

        [Test]
        public void ShouldPostResultStatusToBalancer()
        {
            var fileListWithResults = new[] {"foo/baz: false", "a/b: true"};
            Assert.AreEqual("",_client.PostSuiteResults(fileListWithResults));
        }
    }
}
