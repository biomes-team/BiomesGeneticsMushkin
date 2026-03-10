using Verse;

namespace BiomesGeneticsMushkin
{
	internal class Gene_FungalUndead : MushkinGene
	{

		public override void PostAdd()
		{
			base.PostAdd();
			pawn.health?.AddHediff(DefOfs.BGM_FungalUndead);
		}

		public override void PostRemove()
		{
			base.PostRemove();
			Hediff hediff = pawn.health?.hediffSet?.GetFirstHediffOfDef(DefOfs.BGM_FungalUndead);
			if (hediff != null)
			{
				pawn.health.RemoveHediff(hediff);
			}
		}

	}
}
