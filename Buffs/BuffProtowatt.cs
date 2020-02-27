using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffProtowatt : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Protowatt!");
			Description.SetDefault("Protowatt was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Protowatt")] > 0) {
				modPlayer.summonedProtowatt = true;
			}
			if (!modPlayer.summonedProtowatt) {
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
				player.statDefense += 0;
			}
			
			player.statLifeMax2 += 1;
			player.meleeDamage *= 1.0f;
			player.rangedDamage *= 1.0f;
			player.magicDamage *= 1.0f;
			player.maxRunSpeed += 0.0f;
		}

	}
}