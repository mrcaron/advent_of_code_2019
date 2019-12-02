using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeRunner;
using System.Linq;
using System;
using System.Collections.Generic;

namespace CodeRunner.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow("1,0,0,0,99","2,0,0,0,99")]
        [DataRow("2,3,0,3,99","2,3,0,6,99")]
        [DataRow("2,4,4,5,99,0","2,4,4,5,99,9801")]
        [DataRow("1,1,1,4,99,5,6,0,99","30,1,1,4,2,5,6,0,99")]
        public void TestRunProgram(string input, string output)
        {
            var inputCodes = input.Split(',').ToList().ConvertAll( x => Int32.Parse(x));
            CodeRunner.Program.RunProgram(inputCodes);
            Assert.AreEqual(output, String.Join(',',inputCodes));
        }
    }
}
