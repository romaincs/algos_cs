namespace algos_cs.tests
{
    [TestClass]
    public class UnitBalancedSymbols
    {
        BalancedSymbols bs;

        [TestInitialize]
        public void Init() {
            bs = new BalancedSymbols();
        }

        [TestMethod]
        public void ShouldValidIfContainsBrackets()
        {
            Assert.AreEqual(bs.Verify("{ }"), true);
        }

        [TestMethod]
        public void ShouldValidIfContainsHook()
        {
            Assert.AreEqual(bs.Verify("[ ]"), true);
        }

        [TestMethod]
        public void ShouldValidIfContainsParenthesis()
        {
            Assert.AreEqual(bs.Verify("( )"), true);
        }

        [TestMethod]
        public void ShouldValidIfNested1()
        {
            Assert.AreEqual(bs.Verify("( { } )"), true);
        }

        [TestMethod]
        public void ShouldValidIfNested2()
        {
            Assert.AreEqual(bs.Verify("[ ( { } ) ]"), true);
        }

        [TestMethod]
        public void ShouldValidIfNotClosedCommented()
        {
            Assert.AreEqual(bs.Verify("[ ( /* ( */ { } ) ]"), true);
        }

        [TestMethod]
        public void ShouldNotValidIfNotClosed()
        {
            Assert.AreEqual(bs.Verify("( "), false);
        }

        [TestMethod]
        public void ShouldNotValidIfNestedNotClosed()
        {
            Assert.AreEqual(bs.Verify("[ ( ( { } ) ]"), false);
        }

        [TestMethod]
        public void ShouldNotValidIfClosedAtWrongPlace()
        {
            Assert.AreEqual(bs.Verify("[ ( ( { } ] ) "), false);
        }
    }
}