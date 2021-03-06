using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffStunfiskGalar : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Stunfisk!");
			Description.SetDefault("Stunfisk was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("StunfiskGalar")] > 0) {
				modPlayer.summonedStunfiskGalar = true;
			}
			if (!modPlayer.summonedStunfiskGalar) {
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
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 81;
			player.meleeDamage *= 1.8f;
			player.rangedDamage *= 1.8f;
			player.magicDamage *= 1.7f;
			player.maxRunSpeed += 0.2f;
		}

	}
}