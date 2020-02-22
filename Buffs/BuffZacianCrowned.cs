using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffZacianCrowned : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Zacian!");
			Description.SetDefault("Zacian was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("ZacianCrowned")] > 0) {
				modPlayer.summonedZacianCrowned = true;
			}
			if (!modPlayer.summonedZacianCrowned) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 11;
			}
			else
			{
				player.statDefense += 11;
			}
		}
	}
}