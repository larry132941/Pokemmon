using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffHattrem : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Hattrem!");
			Description.SetDefault("Hattrem was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Hattrem")] > 0) {
				modPlayer.summonedHattrem = true;
			}
			if (!modPlayer.summonedHattrem) {
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
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 40;
			player.meleeDamage *= 1.4f;
			player.rangedDamage *= 1.4f;
			player.magicDamage *= 1.9f;
			player.maxRunSpeed += 0.2f;
		}

	}
}