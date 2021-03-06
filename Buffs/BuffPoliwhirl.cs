using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffPoliwhirl : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Poliwhirl!");
			Description.SetDefault("Poliwhirl was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Poliwhirl")] > 0) {
				modPlayer.summonedPoliwhirl = true;
			}
			if (!modPlayer.summonedPoliwhirl) {
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
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 65;
			player.meleeDamage *= 1.6f;
			player.rangedDamage *= 1.6f;
			player.magicDamage *= 1.5f;
			player.maxRunSpeed += 0.5f;
		}

	}
}