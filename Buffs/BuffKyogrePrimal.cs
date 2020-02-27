using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffKyogrePrimal : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Kyogre!");
			Description.SetDefault("Kyogre was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("KyogrePrimal")] > 0) {
				modPlayer.summonedKyogrePrimal = true;
			}
			if (!modPlayer.summonedKyogrePrimal) {
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
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 16;
			}
			
			player.statLifeMax2 += 150;
			player.meleeDamage *= 2.5f;
			player.rangedDamage *= 2.5f;
			player.magicDamage *= 2.8f;
			player.maxRunSpeed += 0.5f;
		}

	}
}