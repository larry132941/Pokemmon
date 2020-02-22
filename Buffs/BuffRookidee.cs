using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffRookidee : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Rookidee!");
			Description.SetDefault("Rookidee was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Rookidee")] > 0) {
				modPlayer.summonedRookidee = true;
			}
			if (!modPlayer.summonedRookidee) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 3;
			}
			else
			{
				player.statDefense += 3;
			}
		}
	}
}