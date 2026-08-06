using Vintagestory.API.Common;

namespace MetalBowlsAndPots
{
    /// <summary>
    /// Entry point. Registers the block classes referenced by the "class" field in the
    /// blocktype JSON files.
    /// </summary>
    public class MetalBowlsAndPotsModSystem : ModSystem
    {
        public override void Start(ICoreAPI api)
        {
            base.Start(api);

            api.RegisterBlockClass("MetalBowl", typeof(BlockMetalBowl));
            api.RegisterBlockClass("MetalBowlMeal", typeof(BlockMetalBowlMeal));
            api.RegisterBlockClass("MetalCookingContainer", typeof(BlockMetalCookingContainer));
            api.RegisterBlockClass("MetalCookedContainer", typeof(BlockMetalCookedContainer));
        }
    }
}
