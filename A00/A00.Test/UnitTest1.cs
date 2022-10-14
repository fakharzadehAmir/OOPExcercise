using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace A00.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual((A00.Program.IsGreater(15,5)),true);
            Assert.AreEqual((A00.Program.IsGreater(2,3)),false);
        }
    }
}
