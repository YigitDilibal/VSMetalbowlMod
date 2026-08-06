using Vintagestory.API.Common;

namespace MetalBowlsAndPots
{
    /// <summary>
    /// Shared logic for the container blocks in this mod. They can't share a base class because
    /// each one has to extend a different vanilla container, so the common bits live here.
    /// </summary>
    internal static class PerishRate
    {
        public const string AttributeName = "perishRateMul";

        /// <summary>
        /// Reads the per-variant multiplier from the block's JSON attributes. Values below 1
        /// slow spoilage down; a missing attribute leaves the vanilla rate untouched.
        /// </summary>
        public static float FromAttributes(Block block)
        {
            return block.Attributes?[AttributeName].AsFloat(1f) ?? 1f;
        }

        /// <summary>
        /// Only spoilage is slowed. Drying, curing and ripening keep running at the normal rate,
        /// so a bowl doesn't double as a way to stall those recipes.
        /// </summary>
        public static float Apply(float mul, float perishRateMul, EnumTransitionType transType)
        {
            return transType == EnumTransitionType.Perish ? mul * perishRateMul : mul;
        }
    }
}
