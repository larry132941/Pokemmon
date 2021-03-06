using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffKomala : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Komala!");
			Description.SetDefault("Komala was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Komala")] > 0) {
				modPlayer.summonedKomala = true;
			}
			if (!modPlayer.summonedKomala) {
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
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 115;
			player.meleeDamage *= 2.1f;
			player.rangedDamage *= 2.1f;
			player.magicDamage *= 1.8f;
			player.maxRunSpeed += 0.3f;
		}

	}
}