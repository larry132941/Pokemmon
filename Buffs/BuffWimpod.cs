using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffWimpod : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Wimpod!");
			Description.SetDefault("Wimpod was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Wimpod")] > 0) {
				modPlayer.summonedWimpod = true;
			}
			if (!modPlayer.summonedWimpod) {
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
				player.statDefense += 3;
			}
			
			player.statLifeMax2 += 35;
			player.meleeDamage *= 1.4f;
			player.rangedDamage *= 1.4f;
			player.magicDamage *= 1.2f;
			player.maxRunSpeed += 0.4f;
		}

	}
}