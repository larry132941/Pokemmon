using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffFennekin : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Fennekin!");
			Description.SetDefault("Fennekin was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Fennekin")] > 0) {
				modPlayer.summonedFennekin = true;
			}
			if (!modPlayer.summonedFennekin) {
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
			
			player.statLifeMax2 += 45;
			player.meleeDamage *= 1.4f;
			player.rangedDamage *= 1.4f;
			player.magicDamage *= 1.6f;
			player.maxRunSpeed += 0.3f;
		}

	}
}