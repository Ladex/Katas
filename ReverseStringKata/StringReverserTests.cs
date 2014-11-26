using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReverseStringKata
{
    [TestClass]
    public class ReverseStringKata
    {
        [TestMethod]
        public void Reverse_Empty_ReturnEmpty()
        {
            StringReverser sr = new StringReverser();
            Assert.AreEqual(string.Empty, sr.Reverse(string.Empty));
        }

        [TestMethod]
        public void Reverse_HelloWorld_Return()
        {
            StringReverser sr = new StringReverser();
            Assert.AreEqual("dlroWolleH", sr.Reverse("HelloWorld"));
        }


        [TestMethod]
        public void Reverse_Hello_World_Yeepe_Return()
        {
            StringReverser sr = new StringReverser();
            Assert.AreEqual("epeeY dlroW olleH", sr.Reverse("Hello World Yeepe"));
        }

    }
}
