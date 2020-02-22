using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffAggronMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Aggron!");
			Description.SetDefault("Aggron was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("AggronMega")] > 0) {
				modPlayer.summonedAggronMega = true;
			}
			if (!modPlayer.summonedAggronMega) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 23;
			}
			else
			{
				player.statDefense += 8;
			}
		}
	}
}