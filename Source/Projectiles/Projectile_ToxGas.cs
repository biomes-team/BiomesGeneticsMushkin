using RimWorld;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class Projectile_ToxGas : Projectile
	{
		protected override void Impact(Thing hitThing, bool blockedByShield = false)
		{
			base.Impact(hitThing, blockedByShield);
			GenExplosion.DoExplosion(
				DestinationCell,
				MapHeld ?? Launcher.Map,
				1f,
				DamageDefOf.ToxGas,
				Launcher,
				postExplosionGasType: GasType.ToxGas,
				postExplosionGasAmount: 30);
		}
	}
}
