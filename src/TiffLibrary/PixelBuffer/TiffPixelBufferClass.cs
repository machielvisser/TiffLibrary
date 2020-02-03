﻿using System;

namespace TiffLibrary
{
    /// <summary>
    /// Helper class for creating pixel buffer.
    /// </summary>
    public static class TiffPixelBuffer
    {
        /// <summary>
        /// Initial a pixel buffer that wraps a existing <typeparamref name="TPixel"/>[].
        /// </summary>
        /// <typeparam name="TPixel">The pixel type.</typeparam>
        /// <param name="buffer">The memory buffer.</param>
        /// <param name="width">The width of the region.</param>
        /// <param name="height">The height of the region.</param>
        /// <returns>The pixel buffer created.</returns>
        public static TiffPixelBuffer<TPixel> Create<TPixel>(TPixel[] buffer, int width, int height) where TPixel : unmanaged
            => Create(buffer.AsMemory(), width, height);

        /// <summary>
        /// Initial a pixel buffer that wraps a existing Memory&lt;<typeparamref name="TPixel"/>&gt;.
        /// </summary>
        /// <typeparam name="TPixel">The pixel type.</typeparam>
        /// <param name="buffer">The memory buffer.</param>
        /// <param name="width">The width of the region.</param>
        /// <param name="height">The height of the region.</param>
        /// <returns>The pixel buffer created.</returns>
        public static TiffPixelBuffer<TPixel> Create<TPixel>(Memory<TPixel> buffer, int width, int height) where TPixel : unmanaged
        {
            if (width < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width));
            }
            if (height < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height));
            }
            if (buffer.Length < width * height)
            {
                throw new ArgumentException("Pixel buffer is too small.", nameof(buffer));
            }

            return new TiffPixelBuffer<TPixel>(new TiffMemoryPixelBuffer<TPixel>(buffer, width, height));
        }
    }
}
