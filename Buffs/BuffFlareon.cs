using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffFlareon : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Flareon!");
			Description.SetDefault("Flareon was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Flareon")] > 0) {
				modPlayer.summonedFlareon = true;
			}
			if (!modPlayer.summonedFlareon) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 6;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 11;
			}
			
			player.statLifeMax2 += 130;
			player.meleeDamage *= 2.3f;
			player.rangedDamage *= 2.3f;
			player.magicDamage *= 1.9f;
			player.maxRunSpeed += 0.3f;
		}

	}
}