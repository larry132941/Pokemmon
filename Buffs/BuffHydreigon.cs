using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffHydreigon : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Hydreigon!");
			Description.SetDefault("Hydreigon was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Hydreigon")] > 0) {
				modPlayer.summonedHydreigon = true;
			}
			if (!modPlayer.summonedHydreigon) {
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
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 105;
			player.meleeDamage *= 2.0f;
			player.rangedDamage *= 2.0f;
			player.magicDamage *= 2.2f;
			player.maxRunSpeed += 0.5f;
		}

	}
}