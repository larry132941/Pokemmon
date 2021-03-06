using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffAbomasnowMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Abomasnow!");
			Description.SetDefault("Abomasnow was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("AbomasnowMega")] > 0) {
				modPlayer.summonedAbomasnowMega = true;
			}
			if (!modPlayer.summonedAbomasnowMega) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 10;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 132;
			player.meleeDamage *= 2.3f;
			player.rangedDamage *= 2.3f;
			player.magicDamage *= 2.3f;
			player.maxRunSpeed += 0.1f;
		}

	}
}