using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffSwadloon : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Swadloon!");
			Description.SetDefault("Swadloon was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Swadloon")] > 0) {
				modPlayer.summonedSwadloon = true;
			}
			if (!modPlayer.summonedSwadloon) {
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
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 63;
			player.meleeDamage *= 1.6f;
			player.rangedDamage *= 1.6f;
			player.magicDamage *= 1.5f;
			player.maxRunSpeed += 0.2f;
		}

	}
}