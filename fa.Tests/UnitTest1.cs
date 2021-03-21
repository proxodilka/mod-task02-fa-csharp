using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using fans;
namespace NET
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            String s = "0111";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod2()
        {
            String s = "01011";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }   
        [TestMethod]
        public void TestMethod3()
        {
            String s = "110101011";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }  
        [TestMethod]
        public void TestMethod4()
        {
            String s = "1110111";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }  
        [TestMethod]
        public void TestMethod5()
        {
            String s = "10";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        } 
        [TestMethod]
        public void TestMethod6()
        {
            String s = "0101";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }  
        [TestMethod]
        public void TestMethod7()
        {
            String s = "00110011";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }  
        [TestMethod]
        public void TestMethod8()
        {
            String s = "00011";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }
        [TestMethod]
        public void TestMethod9()
        {
          String s = "11";
          FA2 fa = new FA2();
          bool? result = fa.Run(s);
          Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod10()
        {
          String s = "00";
          FA2 fa = new FA2();
          bool? result = fa.Run(s);
          Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod11()
        {
          String s = "";
          FA2 fa = new FA2();
          bool? result = fa.Run(s);
          Assert.IsTrue(result == true);
        }
  }
}
