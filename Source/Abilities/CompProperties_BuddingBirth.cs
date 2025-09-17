using Verse;
using RimWorld;
using System.Collections.Generic;

namespace BiomesGeneticsMushkin
{
	public class CompProperties_BuddingBirth : CompProperties_AbilityEffect
	{
		public CompProperties_BuddingBirth()
		{
			compClass = typeof(AbilityComp_BuddingBirth);
		}

		public List<GeneDef> excludeGenes;
	}
}
