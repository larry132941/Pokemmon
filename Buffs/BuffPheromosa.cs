using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffPheromosa : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Pheromosa!");
			Description.SetDefault("Pheromosa was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Pheromosa")] > 0) {
				modPlayer.summonedPheromosa = true;
			}
			if (!modPlayer.summonedPheromosa) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 3;
			}
			else
			{
				player.statDefense += 3;
			}
		}
	}
}