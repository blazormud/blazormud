using System;
using System.Runtime.CompilerServices;

namespace BlazorMUD.Core.Models.Region
{
    [Flags]
    public enum RegionFlags : ulong
    {
        None = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value01 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0001,
        // Value02 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0010,
        // Value03 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0100,
        // Value04 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_1000,
        // Value05 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0001_0000,
        // Value06 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0010_0000,
        // Value07 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0100_0000,
        // Value08 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_1000_0000,
        // Value09 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0001_0000_0000,
        // Value10 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0010_0000_0000,
        // Value11 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0100_0000_0000,
        // Value12 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_1000_0000_0000,
        // Value13 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0001_0000_0000_0000,
        // Value14 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0010_0000_0000_0000,
        // Value15 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0100_0000_0000_0000,
        // Value16 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_1000_0000_0000_0000,
        // Value17 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0001_0000_0000_0000_0000,
        // Value18 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0010_0000_0000_0000_0000,
        // Value19 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0100_0000_0000_0000_0000,
        // Value20 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_1000_0000_0000_0000_0000,
        // Value21 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0001_0000_0000_0000_0000_0000,
        // Value22 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0010_0000_0000_0000_0000_0000,
        // Value23 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0100_0000_0000_0000_0000_0000,
        // Value24 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_1000_0000_0000_0000_0000_0000,
        // Value25 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0001_0000_0000_0000_0000_0000_0000,
        // Value26 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0010_0000_0000_0000_0000_0000_0000,
        // Value27 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0100_0000_0000_0000_0000_0000_0000,
        // Value28 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_1000_0000_0000_0000_0000_0000_0000,
        // Value29 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0001_0000_0000_0000_0000_0000_0000_0000,
        // Value30 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0010_0000_0000_0000_0000_0000_0000_0000,
        // Value31 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0100_0000_0000_0000_0000_0000_0000_0000,
        // Value32 = 0b_0000_0000_0000_0000_0000_0000_0000_0000_1000_0000_0000_0000_0000_0000_0000_0000,
        // Value33 = 0b_0000_0000_0000_0000_0000_0000_0000_0001_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value34 = 0b_0000_0000_0000_0000_0000_0000_0000_0010_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value35 = 0b_0000_0000_0000_0000_0000_0000_0000_0100_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value36 = 0b_0000_0000_0000_0000_0000_0000_0000_1000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value37 = 0b_0000_0000_0000_0000_0000_0000_0001_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value38 = 0b_0000_0000_0000_0000_0000_0000_0010_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value39 = 0b_0000_0000_0000_0000_0000_0000_0100_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value40 = 0b_0000_0000_0000_0000_0000_0000_1000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value41 = 0b_0000_0000_0000_0000_0000_0001_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value42 = 0b_0000_0000_0000_0000_0000_0010_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value43 = 0b_0000_0000_0000_0000_0000_0100_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value44 = 0b_0000_0000_0000_0000_0000_1000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value45 = 0b_0000_0000_0000_0000_0001_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value46 = 0b_0000_0000_0000_0000_0010_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value47 = 0b_0000_0000_0000_0000_0100_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value48 = 0b_0000_0000_0000_0000_1000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value49 = 0b_0000_0000_0000_0001_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value50 = 0b_0000_0000_0000_0010_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value51 = 0b_0000_0000_0000_0100_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value52 = 0b_0000_0000_0000_1000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value53 = 0b_0000_0000_0001_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value54 = 0b_0000_0000_0010_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value55 = 0b_0000_0000_0100_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value56 = 0b_0000_0000_1000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value57 = 0b_0000_0001_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value58 = 0b_0000_0010_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value59 = 0b_0000_0100_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value60 = 0b_0000_1000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value61 = 0b_0001_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value62 = 0b_0010_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value63 = 0b_0100_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value64 = 0b_1000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000,
        All = 0b_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111_1111,
    }

    public static partial class BitFlagEnumExtensions
    {
        /// <summary>
        /// Sets the specified tag on the bit flag enumeration.
        /// </summary>
        /// <param name="flag">A bit flag to set.</param>
        /// <returns>A copy of the bit flag enumeration with the specified bit flag set.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RegionFlags Set(this RegionFlags @this, RegionFlags flag) => @this |= flag;
        /// <summary>
        /// Unsets the specified tag on the bit flag enumeration.
        /// </summary>
        /// <param name="flag">A bit flag to unset.</param>
        /// <returns>A copy of the bit flag enumeration with the specified bit flag unset.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RegionFlags Unset(this RegionFlags @this, RegionFlags flag) => @this &= ~flag;
        /// <summary>
        /// Toggles the specified tag on the bit flag enumeration.
        /// </summary>
        /// <param name="flag">A bit flag to toggle.</param>
        /// <returns>A copy of the bit flag enumeration with the specified bit flag toggled.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RegionFlags Toggle(this RegionFlags @this, RegionFlags flag) => @this ^= flag;
    }
}
