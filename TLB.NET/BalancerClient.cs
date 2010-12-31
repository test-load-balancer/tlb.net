using System.IO;
using System.Net;
using System.Text;

namespace TLBNETTasks
{
    public class BalancerClient
    {

        private const string BalancerUrl = "http://10.4.4.52:3001/balance";

        public void GetSuiteFilesFromIncludes()
        {
            //10.4.4.52
            var listOfIncludeSuites = "foo/bar\nfoo/baz\n43252435/fadlskkfjdsal\na/b\n";
            var prunedListOfSuites = PostRequestToBalancer(listOfIncludeSuites);
        }

        private string PostRequestToBalancer(string listOfTestSuites)
        {
            HttpWebRequest webRequest = GetWebRequest(listOfTestSuites);
            var webResponse = webRequest.GetResponse();
            StreamReader sr = new StreamReader(webResponse.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        private HttpWebRequest GetWebRequest(string listOfTestSuites)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(BalancerUrl);
            webRequest.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(listOfTestSuites);
            var requestStream = webRequest.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            return webRequest;
        }
    }
}