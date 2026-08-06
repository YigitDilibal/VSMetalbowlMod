using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

namespace MetalBowlsAndPots
{
    /// <summary>
    /// A metal bowl with a meal served into it. This is the variant that actually carries food
    /// around, so it is the one where the preservation bonus matters most.
    /// </summary>
    public class BlockMetalBowlMeal : BlockMeal
    {
        private float perishRateMul = 1f;

        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            perishRateMul = PerishRate.FromAttributes(this);
        }

        public override float GetContainingTransitionModifierContained(IWorldAccessor world, ItemSlot inSlot, EnumTransitionType transType)
        {
            return PerishRate.Apply(base.GetContainingTransitionModifierContained(world, inSlot, transType), perishRateMul, transType);
        }

        public override float GetContainingTransitionModifierPlaced(IWorldAccessor world, BlockPos pos, EnumTransitionType transType)
        {
            return PerishRate.Apply(base.GetContainingTransitionModifierPlaced(world, pos, transType), perishRateMul, transType);
        }
    }
}
