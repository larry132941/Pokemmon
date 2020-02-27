using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffPhantump : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Phantump!");
			Description.SetDefault("Phantump was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Phantump")] > 0) {
				modPlayer.summonedPhantump = true;
			}
			if (!modPlayer.summonedPhantump) {
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
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 70;
			player.meleeDamage *= 1.7f;
			player.rangedDamage *= 1.7f;
			player.magicDamage *= 1.5f;
			player.maxRunSpeed += 0.2f;
		}

	}
}