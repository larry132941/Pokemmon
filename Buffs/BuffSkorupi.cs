using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffSkorupi : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Skorupi!");
			Description.SetDefault("Skorupi was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Skorupi")] > 0) {
				modPlayer.summonedSkorupi = true;
			}
			if (!modPlayer.summonedSkorupi) {
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
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 50;
			player.meleeDamage *= 1.5f;
			player.rangedDamage *= 1.5f;
			player.magicDamage *= 1.3f;
			player.maxRunSpeed += 0.3f;
		}

	}
}