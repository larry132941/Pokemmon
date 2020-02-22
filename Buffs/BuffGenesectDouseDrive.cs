using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffGenesectDouseDrive : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Genesect!");
			Description.SetDefault("Genesect was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("GenesectDouseDrive")] > 0) {
				modPlayer.summonedGenesectDouseDrive = true;
			}
			if (!modPlayer.summonedGenesectDouseDrive) {
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
			else
			{
				player.statDefense += 9;
			}
		}
	}
}