using RimWorld;
using System.Collections.Generic;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class CompProperties_ResurrectionSpores : CompProperties_AbilityEffect
	{

		public List<GeneDef> geneDefs;

		public CompProperties_ResurrectionSpores()
		{
			compClass = typeof(AbilityComp_ResurrectionSpores);
		}
	}
}
