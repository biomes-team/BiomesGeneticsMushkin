using Verse;

namespace BiomesGeneticsMushkin
{
	internal class Gene_FungalUndead : Gene
	{
		public override void PostAdd()
		{
			base.PostAdd();
			pawn.health.AddHediff(DefOfs.BGM_FungalUndead);
		}
	}
}
