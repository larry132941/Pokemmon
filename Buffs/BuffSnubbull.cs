using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffSnubbull : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Snubbull!");
			Description.SetDefault("Snubbull was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Snubbull")] > 0) {
				modPlayer.summonedSnubbull = true;
			}
			if (!modPlayer.summonedSnubbull) {
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
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 80;
			player.meleeDamage *= 1.8f;
			player.rangedDamage *= 1.8f;
			player.magicDamage *= 1.4f;
			player.maxRunSpeed += 0.1f;
		}

	}
}