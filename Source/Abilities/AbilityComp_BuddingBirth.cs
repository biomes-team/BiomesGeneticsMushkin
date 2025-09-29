using RimWorld;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class AbilityComp_BuddingBirth : CompAbilityEffect
	{
		public new CompProperties_BuddingBirth Props => (CompProperties_BuddingBirth)props;


		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{
			base.Apply(target, dest);
			Pawn babyClone = Find.PawnDuplicator.Duplicate(parent.pawn);
			AdjustClone(babyClone);
			GenSpawn.Spawn(babyClone, parent.pawn.Position, parent.pawn.Map);
			if (Props.hediffWhenUsed is not null)
			{
				parent.pawn.health?.AddHediff(Props.hediffWhenUsed);
			}
		}

		private static void AdjustClone(Pawn clone)
		{
			clone.ageTracker.AgeBiologicalTicks = 0;
			clone.genes.SetXenotype(DefOfs.BGM_Mushkin);
		}
	}
}
