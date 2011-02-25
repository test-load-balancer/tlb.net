using System;
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
            var webRequest = (HttpWebRequest)WebRequest.Create(BalancerUrl);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(listOfTestSuites);
            Stream requestStream = webRequest.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            
            var webResponse = webRequest.GetResponse();
            Stream responseStream = webResponse.GetResponseStream();
            if (responseStream != null)
            {
                var sr = new StreamReader(responseStream);
                return sr.ReadToEnd().Trim();
            }
            throw new NotImplementedException("Bu hao");
        }
    }
}