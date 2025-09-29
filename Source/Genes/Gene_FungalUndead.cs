namespace BiomesGeneticsMushkin
{
	internal class Gene_FungalUndead : MushkinGene
	{
		public override void PostAdd()
		{
			base.PostAdd();
			pawn.health.AddHediff(DefOfs.BGM_FungalUndead);
		}
	}
}
