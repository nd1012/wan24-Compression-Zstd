using wan24.Tests;

namespace wan24_Compression_Zstd_Tests
{
    [TestClass]
    public class A_Initialization
    {
        [AssemblyInitialize]
        public static void Init(TestContext tc)
        {
            TestsInitialization.Init(tc);
            wan24.Compression.Zstd.Bootstrap.Boot();
        }
    }
}
