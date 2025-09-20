using RimWorld;
using System.Collections.Generic;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class CompProperties_CasteSwap : CompProperties_AbilityEffect
	{
		public CompProperties_CasteSwap()
		{
			compClass = typeof(AbilityComp_CasteSwap);
		}

		public HediffDef hediffToGive;
		public List<XenotypeDef> allowedXenotypes;
	}
}
