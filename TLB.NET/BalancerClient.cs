using System.IO;
using System.Net;
using System.Text;

namespace NAnt.NUnit2.Tasks
{
    public class BalancerClient
    {

        private const string BalancerUrl = "http://10.4.3.55:3001/balance";

        public string PostRequestToBalancer(string listOfTestSuites)
        {
            HttpWebRequest webRequest = GetWebRequest(listOfTestSuites);
            var webResponse = webRequest.GetResponse();
            StreamReader sr = new StreamReader(webResponse.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        private HttpWebRequest GetWebRequest(string listOfTestSuites)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(BalancerUrl);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(listOfTestSuites);
            var requestStream = webRequest.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            return webRequest;
        }
    }
}