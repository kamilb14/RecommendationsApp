namespace RecommendationsApp.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int i = 0;
            int b = 3;
            LoginForm lg = new LoginForm();

            Assert.AreEqual(1, lg.test(i, b));
        }
    }
}