﻿using System;
using TiffLibrary.Utils;

namespace TiffLibrary
{
    /// <summary>
    /// Represents a unsigned rational.
    /// </summary>
    public readonly struct TiffRational : IEquatable<TiffRational>, IEquatable<TiffSRational>
    {
        /// <summary>
        /// The numerator of the rational.
        /// </summary>
        public uint Numerator { get; }

        /// <summary>
        /// The denominator of the rational.
        /// </summary>
        public uint Denominator { get; }

        /// <summary>
        /// Creates a rational value with the specified numerator and denominator.
        /// </summary>
        /// <param name="numerator">The numerator of the rational.</param>
        /// <param name="denominator">The denominator of the rational.</param>
        public TiffRational(uint numerator, uint denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        /// <summary>
        /// Converts the rational value to <see cref="float"/>.
        /// </summary>
        /// <returns>The rational value in <see cref="float"/>.</returns>
        public float ToSingle()
        {
            return Numerator / (float)Denominator;
        }

        /// <summary>
        /// Converts the rational value to <see cref="double"/>.
        /// </summary>
        /// <returns>The rational value in <see cref="double"/>.</returns>
        public double ToDouble()
        {
            return Numerator / (double)Denominator;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The specified objects</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
        public bool Equals(TiffRational other)
        {
            return Numerator == other.Numerator && Denominator == other.Denominator;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The specified objects</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
        public bool Equals(TiffSRational other)
        {
            return Numerator == other.Numerator && Denominator == other.Denominator;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The specified objects</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            return (obj is TiffRational other && Equals(other)) || (obj is TiffSRational other2 && Equals(other2));
        }

        /// <summary>
        /// Compares two objects for equality.
        /// </summary>
        /// <param name="left">The object on the left side of the operand.</param>
        /// <param name="right">The object on the right side of the operand.</param>
        /// <returns>True if the <paramref name="left"/> parameter is equal to the <paramref name="right"/> parameter; otherwise, false.</returns>
        public static bool operator ==(TiffRational left, TiffRational right) => left.Equals(right);

        /// <summary>
        /// Compares two objects for equality.
        /// </summary>
        /// <param name="left">The object on the left side of the operand.</param>
        /// <param name="right">The object on the right side of the operand.</param>
        /// <returns>True if the <paramref name="left"/> parameter is not equal to the <paramref name="right"/> parameter; otherwise, false.</returns>
        public static bool operator !=(TiffRational left, TiffRational right) => !left.Equals(right);

        /// <summary>
        /// Compares two objects for equality.
        /// </summary>
        /// <param name="left">The object on the left side of the operand.</param>
        /// <param name="right">The object on the right side of the operand.</param>
        /// <returns>True if the <paramref name="left"/> parameter is equal to the <paramref name="right"/> parameter; otherwise, false.</returns>
        public static bool operator ==(TiffRational left, TiffSRational right) => left.Equals(right);

        /// <summary>
        /// Compares two objects for equality.
        /// </summary>
        /// <param name="left">The object on the left side of the operand.</param>
        /// <param name="right">The object on the right side of the operand.</param>
        /// <returns>True if the <paramref name="left"/> parameter is not equal to the <paramref name="right"/> parameter; otherwise, false.</returns>
        public static bool operator !=(TiffRational left, TiffSRational right) => !left.Equals(right);

        /// <summary>
        /// Gets a hash code for the current object.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return HashHelpers.Combine(Numerator.GetHashCode(), Denominator.GetHashCode());
        }
    }

}
