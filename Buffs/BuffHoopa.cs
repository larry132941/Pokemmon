using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffHoopa : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Hoopa!");
			Description.SetDefault("Hoopa was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Hoopa")] > 0) {
				modPlayer.summonedHoopa = true;
			}
			if (!modPlayer.summonedHoopa) {
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
				player.statDefense += 13;
			}
			
			player.statLifeMax2 += 110;
			player.meleeDamage *= 2.1f;
			player.rangedDamage *= 2.1f;
			player.magicDamage *= 2.5f;
			player.maxRunSpeed += 0.3f;
		}

	}
}