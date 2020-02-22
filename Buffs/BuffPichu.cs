using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffPichu : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Pichu!");
			Description.SetDefault("Pichu was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Pichu")] > 0) {
				modPlayer.summonedPichu = true;
			}
			if (!modPlayer.summonedPichu) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 1;
			}
			else
			{
				player.statDefense += 3;
			}
		}
	}
}