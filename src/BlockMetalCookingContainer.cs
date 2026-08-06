using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace MetalBowlsAndPots
{
    /// <summary>
    /// The empty metal cooking pot. Metal conducts heat better than fired clay, so higher tiers
    /// finish a meal faster than the vanilla pot would.
    /// </summary>
    public class BlockMetalCookingContainer : BlockCookingContainer
    {
        public const string CookingTimeAttribute = "cookingTimeMul";

        private float cookingTimeMul = 1f;

        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            cookingTimeMul = Attributes?[CookingTimeAttribute].AsFloat(1f) ?? 1f;
        }

        public override float GetMeltingDuration(IWorldAccessor world, ISlotProvider cookingSlotsProvider, ItemSlot inputSlot)
        {
            return base.GetMeltingDuration(world, cookingSlotsProvider, inputSlot) * cookingTimeMul;
        }
    }
}
