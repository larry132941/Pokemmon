using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffVenipede : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Venipede!");
			Description.SetDefault("Venipede was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Venipede")] > 0) {
				modPlayer.summonedVenipede = true;
			}
			if (!modPlayer.summonedVenipede) {
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
				player.statDefense += 3;
			}
			
			player.statLifeMax2 += 45;
			player.meleeDamage *= 1.4f;
			player.rangedDamage *= 1.4f;
			player.magicDamage *= 1.3f;
			player.maxRunSpeed += 0.3f;
		}

	}
}