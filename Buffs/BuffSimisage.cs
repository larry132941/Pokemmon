using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffSimisage : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Simisage!");
			Description.SetDefault("Simisage was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Simisage")] > 0) {
				modPlayer.summonedSimisage = true;
			}
			if (!modPlayer.summonedSimisage) {
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
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 98;
			player.meleeDamage *= 2.0f;
			player.rangedDamage *= 2.0f;
			player.magicDamage *= 2.0f;
			player.maxRunSpeed += 0.5f;
		}

	}
}