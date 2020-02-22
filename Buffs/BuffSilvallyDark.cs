using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffSilvallyDark : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Silvally!");
			Description.SetDefault("Silvally was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("SilvallyDark")] > 0) {
				modPlayer.summonedSilvallyDark = true;
			}
			if (!modPlayer.summonedSilvallyDark) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 9;
			}
			else
			{
				player.statDefense += 9;
			}
		}
	}
}