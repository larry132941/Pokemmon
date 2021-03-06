using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffOmastar : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Omastar!");
			Description.SetDefault("Omastar was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Omastar")] > 0) {
				modPlayer.summonedOmastar = true;
			}
			if (!modPlayer.summonedOmastar) {
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
			
			player.statLifeMax2 += 60;
			player.meleeDamage *= 1.6f;
			player.rangedDamage *= 1.6f;
			player.magicDamage *= 2.1f;
			player.maxRunSpeed += 0.3f;
		}

	}
}