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
			target.Pawn?.genes?.SetXenotype(Props.xenotypeToTransform);
			if (Rand.Chance(Props.parasitismChance))
			{
				foreach (Gene gene in target.Pawn?.genes?.GenesListForReading)
				{
					if (gene.def == Props.geneOverriddenByParasitism)
					{
						target.Pawn?.genes?.RemoveGene(gene);
						target.Pawn?.genes?.AddGene(Props.parasitismGene, true);
					}
				}
			}
		}
	}
}
