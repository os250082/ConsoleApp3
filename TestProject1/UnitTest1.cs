using ConsoleApp4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class CalcShould
    {
        [TestMethod]
        public void SumTest()
        {
            var calc = new Calc();
            var result = calc.Sum(1, 2);
            Assert.AreEqual(3, result);
        }
    }
}
