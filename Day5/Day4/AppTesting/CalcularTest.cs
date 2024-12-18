using day4.BL;

namespace AppTesting
{
    public class CalculatorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAdd()
        {
            Calculator c = new();
            var res = c.Add(1,2);
            Assert.AreEqual(3,res);
        }
    }
}