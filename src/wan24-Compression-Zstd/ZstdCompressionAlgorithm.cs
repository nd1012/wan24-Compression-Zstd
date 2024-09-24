using System.IO.Compression;
using wan24.Core;
using ZstdSharp;

namespace wan24.Compression.Zstd
{
    /// <summary>
    /// zstd compression algorithm
    /// </summary>
    public sealed record class ZstdCompressionAlgorithm : CompressionAlgorithmBase
    {
        /// <summary>
        /// Algorithm name
        /// </summary>
        public const string ALGORITHM_NAME = "zstd";
        /// <summary>
        /// Algorithm value
        /// </summary>
        public const int ALGORITHM_VALUE = 3;
        /// <summary>
        /// Algorithm display name
        /// </summary>
        public const string DISPLAY_NAME = "zstd";
        /// <summary>
        /// zstd raw (without header) profile key
        /// </summary>
        public const string PROFILE_ZSTD_RAW = "ZSTD_RAW";

        /// <summary>
        /// Static constructor
        /// </summary>
        static ZstdCompressionAlgorithm() => Instance = new();

        /// <summary>
        /// Constructor
        /// </summary>
        private ZstdCompressionAlgorithm() : base(ALGORITHM_NAME, ALGORITHM_VALUE) { }

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static ZstdCompressionAlgorithm Instance { get; }

        /// <inheritdoc/>
        public override string DisplayName => DISPLAY_NAME;

        /// <inheritdoc/>
        protected override Stream CreateCompressionStream(Stream compressedTarget, CompressionOptions options)
        {
            if (options.Level == CompressionLevel.NoCompression) return new LimitedStream(compressedTarget, canRead: false, canWrite: true, canSeek: false, options.LeaveOpen);
            int level = options.Level switch
            {
                CompressionLevel.Fastest => -7,
                CompressionLevel.Optimal => 0,
                CompressionLevel.SmallestSize => 22,
                _ => throw new ArgumentException("Invalid compression level", nameof(options))
            };
            return new CompressionStream(compressedTarget, level, leaveOpen: options.LeaveOpen);
        }

        /// <inheritdoc/>
        protected override Stream CreateDecompressionStream(Stream source, CompressionOptions options) => new DecompressionStream(source, leaveOpen: options.LeaveOpen);
    }
}
