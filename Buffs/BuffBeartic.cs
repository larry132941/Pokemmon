using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffBeartic : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Beartic!");
			Description.SetDefault("Beartic was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Beartic")] > 0) {
				modPlayer.summonedBeartic = true;
			}
			if (!modPlayer.summonedBeartic) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 8;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 130;
			player.meleeDamage *= 2.3f;
			player.rangedDamage *= 2.3f;
			player.magicDamage *= 1.7f;
			player.maxRunSpeed += 0.2f;
		}

	}
}