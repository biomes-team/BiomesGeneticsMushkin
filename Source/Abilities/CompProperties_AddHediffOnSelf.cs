using RimWorld;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class CompProperties_AddHediffOnSelf : CompProperties_AbilityEffect
	{
		public CompProperties_AddHediffOnSelf()
		{
			compClass = typeof(AbilityComp_AddHediffOnSelf);
		}

		public HediffDef hediffDef;
	}
}
