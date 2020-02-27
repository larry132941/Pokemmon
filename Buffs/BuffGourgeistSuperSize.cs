using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffGourgeistSuperSize : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Gourgeist!");
			Description.SetDefault("Gourgeist was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("GourgeistSuperSize")] > 0) {
				modPlayer.summonedGourgeistSuperSize = true;
			}
			if (!modPlayer.summonedGourgeistSuperSize) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 12;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 100;
			player.meleeDamage *= 2.0f;
			player.rangedDamage *= 2.0f;
			player.magicDamage *= 1.6f;
			player.maxRunSpeed += 0.3f;
		}

	}
}