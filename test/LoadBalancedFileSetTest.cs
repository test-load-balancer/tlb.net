using System;
using System.IO;
using NUnit.Framework;

namespace TLB.NET
{
    public class LoadBalancedFileSetTest
    {

        private LoadBalancedFileSet _loadBalancedFileSet;
        private readonly string _tempDirectory = Environment.GetEnvironmentVariable("TEMP");

        [SetUp]
        public void SetUp()
        {
            this._loadBalancedFileSet = new LoadBalancedFileSet();
            File.Create(_tempDirectory + "\\tempFile.dll").Close();
            File.Create(_tempDirectory + "\\tempFile2.dll").Close();
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_tempDirectory + "\\tempFile.dll");
            File.Delete(_tempDirectory + "\\tempFile2.dll");
        }

        [Test]
        public void ShouldReturnFileSetWithIncludedFiles()
        {
            _loadBalancedFileSet.CaseSensitive = true;
            _loadBalancedFileSet.BaseDirectory = new DirectoryInfo(_tempDirectory);
            _loadBalancedFileSet.Includes.Add("temp*.dll");
            Assert.AreEqual(2, _loadBalancedFileSet.FileNames.Count);
        }

    }
}