using Microsoft.VisualStudio.TestTools.UnitTesting;
using FigureAreaLib;

namespace FigureAreaLib_test
{
    [TestClass]
    public class FigureAreaLib_test
    {
        [TestMethod]
        public void CalcAreaCircle_success()
        {
            // arrange
            double R = 2;
            double expected = 12.56636;

            //act
            double actual = FigureArea.Calc(R);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalcAreaCircle_fail()
        {
            // arrange
            double R = -1;
            double expected = double.NaN;

            //act
            double actual = FigureArea.Calc(R);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalcAreaTriangle_scalene_success()
        {
            // arrange
            double ab = 3;
            double bc = 3;
            double ca = 2;
            double expected = 2.8284271247461903;

            //act
            double actual = FigureArea.Calc(ab, bc, ca);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalcAreaTriangle_equilateral_success()
        {
            // arrange
            double ab = 3.1;
            double bc = 3.1;
            double ca = 3.1;
            double expected = 4.161252065184228;

            //act
            double actual = FigureArea.Calc(ab, bc, ca);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalcAreaTriangle_right_success()
        {
            // arrange
            double ab = 6;
            double bc = 10;
            double ca = 8;
            double expected = 24;

            //act
            double actual = FigureArea.Calc(ab, bc, ca);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalcAreaTriangle_fail()
        {
            // arrange
            double ab = 0;
            double bc = 6;
            double ca = 8;
            double expected = double.NaN;

            //act
            double actual = FigureArea.Calc(ab, bc, ca);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalcAreaTriangle_fail_notExist()
        {
            // arrange
            double ab = 2;
            double bc = 2;
            double ca = 8;
            double expected = double.NaN;

            //act
            double actual = FigureArea.Calc(ab, bc, ca);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
