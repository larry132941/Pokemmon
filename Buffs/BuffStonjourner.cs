using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffStonjourner : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Stonjourner!");
			Description.SetDefault("Stonjourner was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Stonjourner")] > 0) {
				modPlayer.summonedStonjourner = true;
			}
			if (!modPlayer.summonedStonjourner) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 13;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 2;
			}
			
			player.statLifeMax2 += 125;
			player.meleeDamage *= 2.2f;
			player.rangedDamage *= 2.2f;
			player.magicDamage *= 1.2f;
			player.maxRunSpeed += 0.3f;
		}

	}
}