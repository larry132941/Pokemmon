using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffVespiquen : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Vespiquen!");
			Description.SetDefault("Vespiquen was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Vespiquen")] > 0) {
				modPlayer.summonedVespiquen = true;
			}
			if (!modPlayer.summonedVespiquen) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 10;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 80;
			player.meleeDamage *= 1.8f;
			player.rangedDamage *= 1.8f;
			player.magicDamage *= 1.8f;
			player.maxRunSpeed += 0.2f;
		}

	}
}