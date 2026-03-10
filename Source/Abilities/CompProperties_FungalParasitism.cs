using RimWorld;
using System;
using System.Collections.Generic;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class CompProperties_FungalParasitism : CompProperties_AbilityEffect
	{
		public CompProperties_FungalParasitism()
		{
			compClass = typeof(AbilityComp_FungalParasitism);
		}

		public GeneDef parasitismGene;
		public List<GeneDef> possibleCapGenes;
		[Obsolete]
		public List<string> resistantXenotypes;
		public float resistanceChance;
	}
}
