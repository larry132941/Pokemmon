using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffCrabrawler : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Crabrawler!");
			Description.SetDefault("Crabrawler was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Crabrawler")] > 0) {
				modPlayer.summonedCrabrawler = true;
			}
			if (!modPlayer.summonedCrabrawler) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 5;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 82;
			player.meleeDamage *= 1.8f;
			player.rangedDamage *= 1.8f;
			player.magicDamage *= 1.4f;
			player.maxRunSpeed += 0.3f;
		}

	}
}