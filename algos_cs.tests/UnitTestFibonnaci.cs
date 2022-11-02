namespace algos_cs.tests
{
    [TestClass]
    public class UnitTestFibonnaci
    {
        [TestMethod]
        public void ShouldReturn0If1Item()
        {
            var f = new Fibonnaci(1);
            Assert.AreEqual(f.Generate(), "0");
        }

        [TestMethod]
        public void ShouldReturn01If2Items()
        {
            var f = new Fibonnaci(2);
            Assert.AreEqual(f.Generate(), "01");
        }

        [TestMethod]
        public void ShouldReturn011If3Items()
        {
            var f = new Fibonnaci(3);
            Assert.AreEqual(f.Generate(), "011");
        }

        [TestMethod]
        public void ShouldReturn011235813If8Items()
        {
            var f = new Fibonnaci(8);
            Assert.AreEqual(f.Generate(), "011235813");
        }
    }
}