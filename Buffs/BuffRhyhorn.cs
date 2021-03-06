using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffRhyhorn : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Rhyhorn!");
			Description.SetDefault("Rhyhorn was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Rhyhorn")] > 0) {
				modPlayer.summonedRhyhorn = true;
			}
			if (!modPlayer.summonedRhyhorn) {
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
				player.statDefense += 3;
			}
			
			player.statLifeMax2 += 85;
			player.meleeDamage *= 1.9f;
			player.rangedDamage *= 1.9f;
			player.magicDamage *= 1.3f;
			player.maxRunSpeed += 0.1f;
		}

	}
}