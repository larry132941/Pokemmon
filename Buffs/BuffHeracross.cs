using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffHeracross : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Heracross!");
			Description.SetDefault("Heracross was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Heracross")] > 0) {
				modPlayer.summonedHeracross = true;
			}
			if (!modPlayer.summonedHeracross) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 7;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 125;
			player.meleeDamage *= 2.2f;
			player.rangedDamage *= 2.2f;
			player.magicDamage *= 1.4f;
			player.maxRunSpeed += 0.4f;
		}

	}
}