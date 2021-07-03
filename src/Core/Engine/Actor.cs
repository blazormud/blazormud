using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BlazorMUD.Core.Engine
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ActorFlags Flags { get; set; }

        public IEnumerable<Item> Items { get; set; }

        public Vendor Vendor { get; set; }
        public bool IsVendor => Vendor != null;
    }

    [Flags]
    public enum ActorFlags : uint
    {
        None = 0b_0000_0000_0000_0000_0000_0000_0000_0000,
        // Value01 = 0b_0000_0000_0000_0000_0000_0000_0000_0001,
        // Value02 = 0b_0000_0000_0000_0000_0000_0000_0000_0010,
        // Value03 = 0b_0000_0000_0000_0000_0000_0000_0000_0100,
        // Value04 = 0b_0000_0000_0000_0000_0000_0000_0000_1000,
        // Value05 = 0b_0000_0000_0000_0000_0000_0000_0001_0000,
        // Value06 = 0b_0000_0000_0000_0000_0000_0000_0010_0000,
        // Value07 = 0b_0000_0000_0000_0000_0000_0000_0100_0000,
        // Value08 = 0b_0000_0000_0000_0000_0000_0000_1000_0000,
        // Value09 = 0b_0000_0000_0000_0000_0000_0001_0000_0000,
        // Value10 = 0b_0000_0000_0000_0000_0000_0010_0000_0000,
        // Value11 = 0b_0000_0000_0000_0000_0000_0100_0000_0000,
        // Value12 = 0b_0000_0000_0000_0000_0000_1000_0000_0000,
        // Value13 = 0b_0000_0000_0000_0000_0001_0000_0000_0000,
        // Value14 = 0b_0000_0000_0000_0000_0010_0000_0000_0000,
        // Value15 = 0b_0000_0000_0000_0000_0100_0000_0000_0000,
        // Value16 = 0b_0000_0000_0000_0000_1000_0000_0000_0000,
        // Value17 = 0b_0000_0000_0000_0001_0000_0000_0000_0000,
        // Value18 = 0b_0000_0000_0000_0010_0000_0000_0000_0000,
        // Value19 = 0b_0000_0000_0000_0100_0000_0000_0000_0000,
        // Value20 = 0b_0000_0000_0000_1000_0000_0000_0000_0000,
        // Value21 = 0b_0000_0000_0001_0000_0000_0000_0000_0000,
        // Value22 = 0b_0000_0000_0010_0000_0000_0000_0000_0000,
        // Value23 = 0b_0000_0000_0100_0000_0000_0000_0000_0000,
        // Value24 = 0b_0000_0000_1000_0000_0000_0000_0000_0000,
        // Value25 = 0b_0000_0001_0000_0000_0000_0000_0000_0000,
        // Value26 = 0b_0000_0010_0000_0000_0000_0000_0000_0000,
        // Value27 = 0b_0000_0100_0000_0000_0000_0000_0000_0000,
        // Value28 = 0b_0000_1000_0000_0000_0000_0000_0000_0000,
        // Value29 = 0b_0001_0000_0000_0000_0000_0000_0000_0000,
        // Value30 = 0b_0010_0000_0000_0000_0000_0000_0000_0000,
        // Value31 = 0b_0100_0000_0000_0000_0000_0000_0000_0000,
        // Value32 = 0b_1000_0000_0000_0000_0000_0000_0000_0000,
        All = 0b_1111_1111_1111_1111_1111_1111_1111_1111,
    }

    public static partial class BitFlagEnumExtensions
    {
        /// <summary>
        /// Sets the specified tag on the bit flag enumeration.
        /// </summary>
        /// <param name="flag">A bit flag to set.</param>
        /// <returns>A copy of the bit flag enumeration with the specified bit flag set.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ActorFlags Set(this ActorFlags @this, ActorFlags flag) => @this |= flag;
        /// <summary>
        /// Unsets the specified tag on the bit flag enumeration.
        /// </summary>
        /// <param name="flag">A bit flag to unset.</param>
        /// <returns>A copy of the bit flag enumeration with the specified bit flag unset.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ActorFlags Unset(this ActorFlags @this, ActorFlags flag) => @this &= ~flag;
        /// <summary>
        /// Toggles the specified tag on the bit flag enumeration.
        /// </summary>
        /// <param name="flag">A bit flag to toggle.</param>
        /// <returns>A copy of the bit flag enumeration with the specified bit flag toggled.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ActorFlags Toggle(this ActorFlags @this, ActorFlags flag) => @this ^= flag;
        /// <summary>
        /// Checks if the big flag enumeration has the specified bit flag set.
        /// </summary>
        /// <param name="flag">A bit flag for which to check.</param>
        /// <returns>Returns <c>true</c> is the bit flag is set; otherwise <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSet(this ActorFlags @this, ActorFlags flag) => (@this & flag) == flag;
    }

}
