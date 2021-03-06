using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffMagnezone : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Magnezone!");
			Description.SetDefault("Magnezone was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Magnezone")] > 0) {
				modPlayer.summonedMagnezone = true;
			}
			if (!modPlayer.summonedMagnezone) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 11;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 70;
			player.meleeDamage *= 1.7f;
			player.rangedDamage *= 1.7f;
			player.magicDamage *= 2.3f;
			player.maxRunSpeed += 0.3f;
		}

	}
}