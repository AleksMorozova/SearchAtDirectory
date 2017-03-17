using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using FileSystemSearch;
using FileSystemSearch.FileWrapper;

namespace UnitTests
{
    [TestClass]
    public class SearchDirectoriesTest
    {
        [TestMethod]
        public void SearchDirectoriesMethod()
        {
            Mock<IProcess> processorDependency = new Mock<IProcess>();

            IFileWrapper fileWrapperDependency =
                Mock.Of<IFileWrapper>(d => d.GetDirectiry("") == new string[1] { @"D:\Main\First" });

            var sut = new DirectoryProcessor(processorDependency.Object, fileWrapperDependency).GetDirectories("");

            var list = new List<string>();
            list.AddRange(sut.Result);

            Assert.IsTrue(list.Contains(@"D:\Main\First"));
        }
    }
}
