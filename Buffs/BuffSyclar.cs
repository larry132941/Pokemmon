using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffSyclar : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Syclar!");
			Description.SetDefault("Syclar was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Syclar")] > 0) {
				modPlayer.summonedSyclar = true;
			}
			if (!modPlayer.summonedSyclar) {
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
				player.statDefense += 3;
			}
			
			player.statLifeMax2 += 76;
			player.meleeDamage *= 1.8f;
			player.rangedDamage *= 1.8f;
			player.magicDamage *= 1.7f;
			player.maxRunSpeed += 0.5f;
		}

	}
}