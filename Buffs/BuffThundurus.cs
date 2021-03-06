using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffThundurus : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Thundurus!");
			Description.SetDefault("Thundurus was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Thundurus")] > 0) {
				modPlayer.summonedThundurus = true;
			}
			if (!modPlayer.summonedThundurus) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 7;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 115;
			player.meleeDamage *= 2.1f;
			player.rangedDamage *= 2.1f;
			player.magicDamage *= 2.2f;
			player.maxRunSpeed += 0.6f;
		}

	}
}