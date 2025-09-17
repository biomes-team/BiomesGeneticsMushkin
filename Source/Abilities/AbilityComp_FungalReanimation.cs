using RimWorld;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class AbilityComp_FungalReanimation : CompAbilityEffect
	{
		public new CompProperties_FungalReanimation Props => (CompProperties_FungalReanimation)props;


		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{
			base.Apply(target, dest);
			if (target.Thing is Corpse corpse)
			{
				Pawn ressedPawn = corpse.InnerPawn;
				ResurrectionUtility.TryResurrect(corpse.InnerPawn);
				ressedPawn.genes?.AddGene(Props.reanimationGene, true);
			}
		}
	}
}
