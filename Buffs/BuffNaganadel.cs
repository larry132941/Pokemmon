using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffNaganadel : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Naganadel!");
			Description.SetDefault("Naganadel was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Naganadel")] > 0) {
				modPlayer.summonedNaganadel = true;
			}
			if (!modPlayer.summonedNaganadel) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 7;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 73;
			player.meleeDamage *= 1.7f;
			player.rangedDamage *= 1.7f;
			player.magicDamage *= 2.3f;
			player.maxRunSpeed += 0.6f;
		}

	}
}