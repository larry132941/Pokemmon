using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffFurfrouKabukiTrim : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Furfrou!");
			Description.SetDefault("Furfrou was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("FurfrouKabukiTrim")] > 0) {
				modPlayer.summonedFurfrouKabukiTrim = true;
			}
			if (!modPlayer.summonedFurfrouKabukiTrim) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 6;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 80;
			player.meleeDamage *= 1.8f;
			player.rangedDamage *= 1.8f;
			player.magicDamage *= 1.6f;
			player.maxRunSpeed += 0.5f;
		}

	}
}