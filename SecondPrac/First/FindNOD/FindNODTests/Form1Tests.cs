using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindNOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNOD.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void FindNODTest()
        {
            int A = 2806;
            int B = 345;
            int Expected = 23;
            Assert.AreEqual(Expected, Form1.FindNOD(A, B));
        }

        [TestMethod()]
        public void FindNODTest1()
        {
            int A = 2806;
            int B = 345;
            int C = 161;
            int Expected = 23;
            Assert.AreEqual(Expected, Form1.FindNOD(A, B, C));
        }

        [TestMethod()]
        public void FindNODTest2()
        {
            int A = 2806;
            int B = 345;
            int C = 161;
            int D = 138;
            int Expected = 23;
            Assert.AreEqual(Expected, Form1.FindNOD(A, B, C, D));
        }

        [TestMethod()]
        public void FindNODTest3()
        {
            int A = 2806;
            int B = 345;
            int C = 161;
            int D = 138;
            int E = 115;
            int Expected = 23;
            Assert.AreEqual(Expected, Form1.FindNOD(A, B, C, D, E));
        }

        [TestMethod()]
        public void FindNODTest4()
        {
            int[] Nums = { 2806, 345, 161, 138, 115, 92 };
            int Expected = 23;
            Assert.AreEqual(Expected, Form1.FindNOD(Nums));
        }

        [TestMethod()]
        public void FindGCDSteinTest()
        {
            int A = 123456545;
            int B = 4894895;
            int Expected = 5;
            Assert.AreEqual(Expected, Form1.FindGCDStein(A, B));
        }
    }
}