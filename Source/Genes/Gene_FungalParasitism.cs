using Verse;

namespace BiomesGeneticsMushkin
{
	public class Gene_FungalParasitism : Gene
	{
		public override void PostAdd()
		{
			base.PostAdd();
			pawn.health.AddHediff(DefOfs.BGM_FungalParasite);
		}
	}
}
