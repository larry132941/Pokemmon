using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffDewpider : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Dewpider!");
			Description.SetDefault("Dewpider was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Dewpider")] > 0) {
				modPlayer.summonedDewpider = true;
			}
			if (!modPlayer.summonedDewpider) {
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
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 40;
			player.meleeDamage *= 1.4f;
			player.rangedDamage *= 1.4f;
			player.magicDamage *= 1.4f;
			player.maxRunSpeed += 0.1f;
		}

	}
}