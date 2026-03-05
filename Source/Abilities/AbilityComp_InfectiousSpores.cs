using RimWorld;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class AbilityComp_InfectiousSpores : CompAbilityEffect
	{
		public new CompProperties_InfectiousSpores Props => (CompProperties_InfectiousSpores)props;


		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{
			base.Apply(target, dest);
			Pawn pawn = target.Pawn;
			pawn?.genes?.SetXenotype(Props.xenotypeToTransform);
			if (Props.hediffDef != null)
			{
				pawn?.health.AddHediff(Props.hediffDef);
			}
			if (Rand.Chance(Props.parasitismChance))
			{
				foreach (Gene gene in target.Pawn?.genes?.GenesListForReading)
				{
					if (gene.def == Props.geneOverriddenByParasitism)
					{
						pawn?.genes?.RemoveGene(gene);
						pawn?.genes?.AddGene(Props.parasitismGene, true);
					}
				}
			}
		}
	}
}
