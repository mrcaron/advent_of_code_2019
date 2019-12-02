using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeRunner;

namespace CodeRunner.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow("1,0,0,0,99","2,0,0,0,99")]
        public void TestRunProgram(string input, string output)
        {
            Assert.AreEqual(output, CodeRunner.Program.RunProgram(input));
        }
    }
}
