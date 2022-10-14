using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace A0.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual((A0.Program.Max(5,15)),15);
            Assert.AreEqual((A0.Program.Max(2,3)),3);
        }
    }
}
