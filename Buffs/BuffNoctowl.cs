using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffNoctowl : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Noctowl!");
			Description.SetDefault("Noctowl was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Noctowl")] > 0) {
				modPlayer.summonedNoctowl = true;
			}
			if (!modPlayer.summonedNoctowl) {
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
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 50;
			player.meleeDamage *= 1.5f;
			player.rangedDamage *= 1.5f;
			player.magicDamage *= 1.9f;
			player.maxRunSpeed += 0.3f;
		}

	}
}