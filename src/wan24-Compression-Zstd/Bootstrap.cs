using wan24.Core;

[assembly: Bootstrapper(typeof(wan24.Compression.Zstd.Bootstrap), nameof(wan24.Compression.Zstd.Bootstrap.Boot))]

namespace wan24.Compression.Zstd
{
    /// <summary>
    /// Bootstrapper
    /// </summary>
    public static class Bootstrap
    {
        /// <summary>
        /// Boot
        /// </summary>
        public static void Boot()
        {
            CompressionHelper.Algorithms[ZstdCompressionAlgorithm.ALGORITHM_NAME] = ZstdCompressionAlgorithm.Instance;
            CompressionProfiles.Registered[ZstdCompressionAlgorithm.PROFILE_ZSTD_RAW] = new CompressionOptions()
                .IncludeNothing()
                .WithAlgorithm(ZstdCompressionAlgorithm.ALGORITHM_NAME);
        }
    }
}
