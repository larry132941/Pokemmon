using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffEmbirch : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Embirch!");
			Description.SetDefault("Embirch was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Embirch")] > 0) {
				modPlayer.summonedEmbirch = true;
			}
			if (!modPlayer.summonedEmbirch) {
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
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 40;
			player.meleeDamage *= 1.4f;
			player.rangedDamage *= 1.4f;
			player.magicDamage *= 1.6f;
			player.maxRunSpeed += 0.3f;
		}

	}
}