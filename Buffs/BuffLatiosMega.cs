using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffLatiosMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Latios!");
			Description.SetDefault("Latios was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("LatiosMega")] > 0) {
				modPlayer.summonedLatiosMega = true;
			}
			if (!modPlayer.summonedLatiosMega) {
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
				player.statDefense += 12;
			}
			
			player.statLifeMax2 += 130;
			player.meleeDamage *= 2.3f;
			player.rangedDamage *= 2.3f;
			player.magicDamage *= 2.6f;
			player.maxRunSpeed += 0.6f;
		}

	}
}