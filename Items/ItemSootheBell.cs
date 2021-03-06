using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemSootheBell : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soothe Bell");
			Tooltip.SetDefault("Evolves Pokemon that need Friendship");
		}
		public override void SetDefaults()
		{
			item.width = 15;
			item.height = 20;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 4;//Like Fallen Star
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item4;//Like Fallen Star
            item.maxStack = 999;
			item.value = 50000;
		}
		
		
	}
}
