using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab4stp;

namespace lab4stptest2
{
    namespace MatrixTests
    {
        [TestClass]
        public class MatrixTests
        {
            [TestMethod]
            [ExpectedException(typeof(MyException))]
            public void Matrix_Expected_MyException_i()
            {
                //act (выполнить)
                Matrix a = new Matrix(0, 2);
            }

            [TestMethod]
            [ExpectedException(typeof(MyException))]
            public void Matrix_Expected_MyException_j()
            {
                //act (выполнить)
                Matrix a = new Matrix(2, -1);
            }

            [TestMethod]
            [ExpectedException(typeof(MyException))]
            public void this_Expected_MyException_set_j()
            {
                //act (выполнить)
                Matrix a = new Matrix(2, 2);
                a[1, 3] = 2;
            }

            [TestMethod]
            [ExpectedException(typeof(MyException))]
            public void this_Expected_MyException_get_i()
            {
                //act (выполнить)
                Matrix a = new Matrix(2, 2);
                int r = a[3, 1];
            }

            [TestMethod]
            public void Equel()
            {
                //arrange(обеспечить)
                Matrix a = new Matrix(2, 2);
                a[0, 0] = 1;
                a[0, 1] = 1;
                a[1, 0] = 1;
                a[1, 1] = 1;
                Matrix b = new Matrix(2, 2);
                b[0, 0] = 1;
                b[0, 1] = 1;
                b[1, 0] = 1;
                b[1, 1] = 1;
                //act (выполнить)
                //bool r = a == b;
                //assert(доказать)
                //Assert.IsTrue(r);
                Assert.AreEqual(a, b);
            }

            [TestMethod]
            public void Summ()
            {
                //arrange(обеспечить)
                Matrix a = new Matrix(2, 2);
                a[0, 0] = 1;
                a[0, 1] = 1;
                a[1, 0] = 1;
                a[1, 1] = 1;
                Matrix b = new Matrix(2, 2);
                b[0, 0] = 2;
                b[0, 1] = 2;
                b[1, 0] = 2;
                b[1, 1] = 2;
                Matrix expected = new Matrix(2, 2);
                expected[0, 0] = 3; expected[0, 1] = 3;
                expected[1, 0] = 3; expected[1, 1] = 3;
                Matrix actual = new Matrix(2, 2);
                //act (выполнить)
                actual = a + b;
                //assert(доказать)
                Assert.IsTrue(actual == expected);//Оракул
            }

            [TestMethod]
            public void Subtr()
            {
                //arrange(обеспечить)
                Matrix a = new Matrix(2, 2);
                a[0, 0] = 1;
                a[0, 1] = 1;
                a[1, 0] = 1;
                a[1, 1] = 1;
                Matrix b = new Matrix(2, 2);
                b[0, 0] = 2;
                b[0, 1] = 2;
                b[1, 0] = 2;
                b[1, 1] = 2;
                Matrix expected = new Matrix(2, 2);
                expected[0, 0] = -1; expected[0, 1] = -1;
                expected[1, 0] = -1; expected[1, 1] = -1;
                Matrix actual = a - b;
                //assert(доказать)
                Assert.IsTrue(actual == expected);//Оракул
            }

            [TestMethod]
            public void Mult()
            {
                //arrange(обеспечить)
                Matrix a = new Matrix(2, 2);
                a[0, 0] = 1;
                a[0, 1] = 1;
                a[1, 0] = 1;
                a[1, 1] = 1;
                Matrix b = new Matrix(2, 2);
                b[0, 0] = 2;
                b[0, 1] = 2;
                b[1, 0] = 2;
                b[1, 1] = 2;
                Matrix expected = new Matrix(2, 2);
                expected[0, 0] = 4; expected[0, 1] = 4;
                expected[1, 0] = 4; expected[1, 1] = 4;
                Matrix actual = a * b;
                //assert(доказать)
                Assert.IsTrue(actual == expected);//Оракул
            }

            [TestMethod]
            [ExpectedException(typeof(MyException))]
            public void MultException()
            {
                //arrange(обеспечить)
                Matrix a = new Matrix(2, 2);
                a[0, 0] = 1;
                a[0, 1] = 1;
                a[1, 0] = 1;
                a[1, 1] = 1;
                Matrix b = new Matrix(1, 2);
                b[0, 0] = 2;
                b[0, 1] = 2;
                Matrix actual = a * b;
            }

            [TestMethod]
            public void Rows()
            {
                Matrix a = new Matrix(1, 2);
                a[0, 0] = 1;
                a[0, 1] = 1;
                int rows = Matrix.GetRows(a);
                int actual = 1;
                Assert.AreEqual(actual, rows);
            }

            [TestMethod]
            public void Cols()
            {
                Matrix a = new Matrix(2, 1);
                a[0, 0] = 1;
                a[1, 0] = 1;
                int cols = Matrix.GetCols(a);
                int actual = 1;
                Assert.AreEqual(actual, cols);
            }

            [TestMethod]
            public void Transp()
            {
                Matrix a = new Matrix(2, 2);
                a[0, 0] = 1;
                a[0, 1] = 1;
                a[1, 0] = 2;
                a[1, 1] = 2;
                Matrix expect = new Matrix(2, 2);
                expect[0, 0] = 1;
                expect[0, 1] = 2;
                expect[1, 0] = 1;
                expect[1, 1] = 2;
                Matrix actual = Matrix.Transp(a);
                Assert.IsTrue(actual == expect);
            }

            [TestMethod]
            public void StringTest()
            {
                Matrix a = new Matrix(2, 2);
                a[0, 0] = 2;
                a[0, 1] = 2;
                a[1, 0] = 1;
                a[1, 1] = 1;
                string expect = "{ { 2, 2 }, { 1, 1 } }";
                string actual = Matrix.MatrixToString(a);
                Assert.AreEqual(expect, actual);
            }

            [TestMethod]
            public void MinTest()
            {
                Matrix a = new Matrix(2, 2);
                a[0, 0] = 2;
                a[0, 1] = 2;
                a[1, 0] = 3;
                a[1, 1] = 1;
                int expect = 1;
                int actual = Matrix.Min(a);
                Assert.AreEqual(expect, actual);
            }
        }
    }
}
