using System;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using NAnt.Core.Attributes;
using NAnt.DotNet.Types;

namespace NAnt.Core.Types
{
    public class LoadBalancedFileSet : AssemblyFileSet
    {
        private const string BalancerUrl = "http://10.4.4.52:3001/balance";

        [BuildElementArray("loadbalancedincludes")]
        public Include[] LoadBalancedIncludes
        {
            set { Scan(); }
        }

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
            var webRequest = (HttpWebRequest) WebRequest.Create(BalancerUrl);
            webRequest.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(listOfTestSuites);
            var requestStream = webRequest.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            return webRequest;
        }
        
        
        public override void Scan()
        {
            base.Scan();

            throw new NotImplementedException("In Scan()");
        }

    }
}