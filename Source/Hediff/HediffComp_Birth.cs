using Verse;

namespace BiomesGeneticsMushkin
{
	public class HediffComp_Birth : HediffComp
	{
		public HediffCompProperties_Birth Props => (HediffCompProperties_Birth)props;


		public override void CompPostPostAdd(DamageInfo? dinfo)
		{
			base.CompPostPostAdd(dinfo);
			Pawn babyClone = Find.PawnDuplicator.Duplicate(parent.pawn);
			AdjustClone(babyClone);
			GenSpawn.Spawn(babyClone, parent.pawn.Position, parent.pawn.Map);
		}


		private static void AdjustClone(Pawn clone)
		{
			clone.ageTracker.AgeBiologicalTicks = 0;
			clone.genes.SetXenotype(DefOfs.BGM_Mushkin);
		}
	}
}
