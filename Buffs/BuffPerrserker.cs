using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffPerrserker : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Perrserker!");
			Description.SetDefault("Perrserker was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Perrserker")] > 0) {
				modPlayer.summonedPerrserker = true;
			}
			if (!modPlayer.summonedPerrserker) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 10;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 110;
			player.meleeDamage *= 2.1f;
			player.rangedDamage *= 2.1f;
			player.magicDamage *= 1.5f;
			player.maxRunSpeed += 0.2f;
		}

	}
}