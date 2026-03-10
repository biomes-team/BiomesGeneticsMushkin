using Verse;

namespace BiomesGeneticsMushkin
{
	public class Gene_FungalParasitism : MushkinGene
	{

		public override void PostAdd()
		{
			base.PostAdd();
			pawn.health?.AddHediff(DefOfs.BGM_FungalParasite);
		}

		public override void PostRemove()
		{
			base.PostRemove();
			Hediff hediff = pawn.health?.hediffSet?.GetFirstHediffOfDef(DefOfs.BGM_FungalParasite);
			if (hediff != null)
			{
				pawn.health.RemoveHediff(hediff);
			}
		}

	}
}
