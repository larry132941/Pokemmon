using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffPikachuRockStar : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Pikachu!");
			Description.SetDefault("Pikachu was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("PikachuRockStar")] > 0) {
				modPlayer.summonedPikachuRockStar = true;
			}
			if (!modPlayer.summonedPikachuRockStar) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 4;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 55;
			player.meleeDamage *= 1.6f;
			player.rangedDamage *= 1.6f;
			player.magicDamage *= 1.5f;
			player.maxRunSpeed += 0.5f;
		}

	}
}