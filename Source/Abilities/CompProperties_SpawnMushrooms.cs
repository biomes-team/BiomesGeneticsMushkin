using RimWorld;
using System.Collections.Generic;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class CompProperties_SpawnMushrooms : CompProperties_AbilityEffect
	{
		public CompProperties_SpawnMushrooms()
		{
			compClass = typeof(AbilityComp_SpawnMushrooms);
		}

		public float range;
		public List<ThingDef> plantsToSpawn;
	}
}
