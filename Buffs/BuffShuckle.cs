using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffShuckle : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Shuckle!");
			Description.SetDefault("Shuckle was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Shuckle")] > 0) {
				modPlayer.summonedShuckle = true;
			}
			if (!modPlayer.summonedShuckle) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 23;
			}
			else
			{
				player.statDefense += 23;
			}
		}
	}
}