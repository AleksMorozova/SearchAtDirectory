using FileSystemSearch;
using FileSystemSearch.FileWrapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class SearchFilesTest
    {
        [TestMethod]
        public void SearchFilesMethod()
        {
            Mock<IProcess> processorDependency = new Mock<IProcess>();

            IFileWrapper fileWrapperDependency =
                Mock.Of<IFileWrapper>(d => d.GetFiles("") == new string[1] { @"D:\Main\First\Test.txt" });

            var sut = new DirectoryProcessor(processorDependency.Object, fileWrapperDependency).GetFiles("");

            var list = new List<string>();
            list.AddRange(sut.Result);

            Assert.IsTrue(list.Contains(@"D:\Main\First\Test.txt"));
        }
    }
}
