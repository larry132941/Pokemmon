using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffBruxish : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Bruxish!");
			Description.SetDefault("Bruxish was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Bruxish")] > 0) {
				modPlayer.summonedBruxish = true;
			}
			if (!modPlayer.summonedBruxish) {
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
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 105;
			player.meleeDamage *= 2.0f;
			player.rangedDamage *= 2.0f;
			player.magicDamage *= 1.7f;
			player.maxRunSpeed += 0.5f;
		}

	}
}