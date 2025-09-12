using RimWorld;
using System.Collections.Generic;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class CompProperties_HediffGiverArea : CompProperties_AbilityEffect
	{
		public CompProperties_HediffGiverArea()
		{
			compClass = typeof(AbilityComp_HediffGiverArea);
		}

		public HediffDef hediffDef;
		public float range;
		public List<XenotypeDef> xenotypesImmuneToDebuff;
		public FleckDef effecter;
	}
}
