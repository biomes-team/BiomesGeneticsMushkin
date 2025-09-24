using RimWorld;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class CompProperties_InfectiousSpores : CompProperties_AbilityEffect
	{
		public CompProperties_InfectiousSpores()
		{
			compClass = typeof(AbilityComp_InfectiousSpores);
		}

		public XenotypeDef xenotypeToTransform;
		public GeneDef geneOverriddenByParasitism;
		public GeneDef parasitismGene;
		public float parasitismChance;
	}
}
