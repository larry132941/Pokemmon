using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffElectrode : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Electrode!");
			Description.SetDefault("Electrode was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Electrode")] > 0) {
				modPlayer.summonedElectrode = true;
			}
			if (!modPlayer.summonedElectrode) {
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
			
			player.statLifeMax2 += 50;
			player.meleeDamage *= 1.5f;
			player.rangedDamage *= 1.5f;
			player.magicDamage *= 1.8f;
			player.maxRunSpeed += 0.8f;
		}

	}
}