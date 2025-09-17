using RimWorld;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class CompProperties_FungalReanimation : CompProperties_AbilityEffect
	{
		public CompProperties_FungalReanimation()
		{
			compClass = typeof(AbilityComp_FungalReanimation);
		}

		public GeneDef reanimationGene;
	}
}
