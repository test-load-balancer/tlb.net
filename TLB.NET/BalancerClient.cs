using System;
using System.IO;
using System.Net;
using System.Text;

namespace TLBNETTasks
{
    public class BalancerClient
    {
        private readonly string _host;
        private readonly int _port;

        public BalancerClient(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public string[] GetSuiteFilesFromIncludes(string[] fileList)
        {
            string listOfIncludeSuites = string.Join("\n", fileList);
            string prunedListOfSuites = GetResponseFromBalancer("balance", listOfIncludeSuites);
            return prunedListOfSuites.Split(new[] {"\n"}, StringSplitOptions.None);
        }

        public string PostSuiteTimes(string[] fileListWithTimes)
        {
            string listOfSuiteTimes = string.Join("\n", fileListWithTimes);
            return GetResponseFromBalancer("suite_time", listOfSuiteTimes);
        }

        public string PostSuiteResults(string[] fileListWithResults)
        {
            string listOfSuiteResults = string.Join("\n", fileListWithResults);
            return GetResponseFromBalancer("suite_result", listOfSuiteResults);
        }

        private Uri GetBalancerUrl(string route)
        {
            return new UriBuilder("http", _host, _port, route).Uri;
        }

        private string GetResponseFromBalancer(string route, string dataToPost)
        {
            var webRequest = (HttpWebRequest) WebRequest.Create(GetBalancerUrl(route));
            webRequest.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(dataToPost);
            Stream requestStream = webRequest.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            var webResponse = webRequest.GetResponse();
            Stream responseStream = webResponse.GetResponseStream();
            if (responseStream != null)
            {
                var sr = new StreamReader(responseStream);
                return sr.ReadToEnd().Trim();
            }
            return dataToPost;
        }
    }
}