namespace algos_cs.tests
{
    [TestClass]
    public class UnitWaterJug
    {
        [TestMethod]
        public void ShouldReturn6ItemsIfCapacitiesAre3And5AndTargetIs4()
        {
            var res = WaterJug.FindPourOperations(4, new int[] { 3, 5 });
            Assert.AreEqual(res.Count(), 6);
        }

        [TestMethod]
        public void ShouldReturn6ItemsIfCapacitiesAre5And3AndTargetIs4()
        {
            var res = WaterJug.FindPourOperations(4, new int[] { 5, 3 });
            Assert.AreEqual(res.Count(), 6);
        }

        [TestMethod]
        public void ShouldReturnNullIfCapacitiesAre5And10AndTargetIs7()
        {
            var res = WaterJug.FindPourOperations(7, new int[] { 5, 10 });
            Assert.IsNull(res);
        }

        [TestMethod]
        public void ShouldReturnNullIfCapacitiesAre6And10AndTargetIs5()
        {
            var res = WaterJug.FindPourOperations(5, new int[] { 6, 10 });
            Assert.IsNull(res);

        }

        [TestMethod]
        public void ShouldReturnNullIfSingleCapacitie()
        {
            var res = WaterJug.FindPourOperations(5, new int[] { 6 });
            Assert.IsNull(res);

        }
    }
}