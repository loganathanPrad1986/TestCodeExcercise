using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class TestFileData
    {
        [DataTestMethod]
        [DataRow("-v", "c:/test.txt")]
        [DataRow("--v", "c:/test.txt")]
        [DataRow("/v", "c:/test.txt")]
        [DataRow("--version", "c:/test.txt")]
        [DataRow("-s", "c:/test.txt")]
        [DataRow("-s", "c:/test.txt")]
        [DataRow("--s", "c:/test.txt")]
        [DataRow("/s", "c:/test.txt")]
        [DataRow("--size", "c:/test.txt")]
        public void TestFileValidInputs(string fileOption, string filePath)
        {
            var actual = FileData.Program.ReturnFileInformation(fileOption, filePath);
            Assert.AreNotEqual(FileData.Constant.invalidMessage, actual);

        }


        [DataTestMethod]
        [DataRow("", "c:/test.txt")]
        [DataRow("", "")]
        [DataRow("ABC", "")]
        public void TestInputArgument(string fileOption, string filePath)
        {
            var actual = FileData.Program.ReturnFileInformation(fileOption, filePath);
            Assert.AreEqual(FileData.Constant.invalidMessage, actual);

        }
    }

}

