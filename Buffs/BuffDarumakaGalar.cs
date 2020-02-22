using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffDarumakaGalar : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Darumaka!");
			Description.SetDefault("Darumaka was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("DarumakaGalar")] > 0) {
				modPlayer.summonedDarumakaGalar = true;
			}
			if (!modPlayer.summonedDarumakaGalar) {
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
			else
			{
				player.statDefense += 4;
			}
		}
	}
}