using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffChansey : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Chansey!");
			Description.SetDefault("Chansey was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Chansey")] > 0) {
				modPlayer.summonedChansey = true;
			}
			if (!modPlayer.summonedChansey) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 0;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 5;
			player.meleeDamage *= 1.1f;
			player.rangedDamage *= 1.1f;
			player.magicDamage *= 1.4f;
			player.maxRunSpeed += 0.2f;
		}

	}
}