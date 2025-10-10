using RimWorld;
using RimWorld.Planet;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class AbilityComp_AddHediffOnSelf : CompAbilityEffect
	{
		public new CompProperties_AddHediffOnSelf Props => (CompProperties_AddHediffOnSelf)props;


		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{
			base.Apply(target, dest);
			Hediff hediff = HediffMaker.MakeHediff(Props.hediffDef, parent.pawn);
			parent.pawn.health.AddHediff(hediff);
		}
	}
}
