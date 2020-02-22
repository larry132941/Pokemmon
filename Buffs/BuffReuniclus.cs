using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffReuniclus : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Reuniclus!");
			Description.SetDefault("Reuniclus was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Reuniclus")] > 0) {
				modPlayer.summonedReuniclus = true;
			}
			if (!modPlayer.summonedReuniclus) {
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
			else
			{
				player.statDefense += 8;
			}
		}
	}
}