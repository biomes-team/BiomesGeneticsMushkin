namespace BiomesGeneticsMushkin
{
	public class Gene_FungalParasitism : MushkinGene
	{
		public override void PostAdd()
		{
			base.PostAdd();
			pawn.health.AddHediff(DefOfs.BGM_FungalParasite);
		}
	}
}
