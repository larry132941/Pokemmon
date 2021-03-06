using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffVolcarona : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Volcarona!");
			Description.SetDefault("Volcarona was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Volcarona")] > 0) {
				modPlayer.summonedVolcarona = true;
			}
			if (!modPlayer.summonedVolcarona) {
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
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 60;
			player.meleeDamage *= 1.6f;
			player.rangedDamage *= 1.6f;
			player.magicDamage *= 2.4f;
			player.maxRunSpeed += 0.5f;
		}

	}
}