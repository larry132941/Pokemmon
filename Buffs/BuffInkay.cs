using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffInkay : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Inkay!");
			Description.SetDefault("Inkay was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Inkay")] > 0) {
				modPlayer.summonedInkay = true;
			}
			if (!modPlayer.summonedInkay) {
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
			
			player.statLifeMax2 += 54;
			player.meleeDamage *= 1.5f;
			player.rangedDamage *= 1.5f;
			player.magicDamage *= 1.4f;
			player.maxRunSpeed += 0.2f;
		}

	}
}