using RimWorld;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class CompProperties_BuddingBirth : CompProperties_AbilityEffect
	{
		public CompProperties_BuddingBirth()
		{
			compClass = typeof(AbilityComp_BuddingBirth);
		}

		public HediffDef hediffWhenUsed;
	}
}
