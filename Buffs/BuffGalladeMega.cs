using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffGalladeMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Gallade!");
			Description.SetDefault("Gallade was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("GalladeMega")] > 0) {
				modPlayer.summonedGalladeMega = true;
			}
			if (!modPlayer.summonedGalladeMega) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 9;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 11;
			}
			
			player.statLifeMax2 += 165;
			player.meleeDamage *= 2.6f;
			player.rangedDamage *= 2.6f;
			player.magicDamage *= 1.6f;
			player.maxRunSpeed += 0.6f;
		}

	}
}