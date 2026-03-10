using RimWorld;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class AbilityComp_FungalParasitism : CompAbilityEffect
	{
		public new CompProperties_FungalParasitism Props => (CompProperties_FungalParasitism)props;


		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{
			base.Apply(target, dest);
			Pawn pawn = target.Pawn;
			if (pawn?.genes != null)
			{
				// if (Props.resistantXenotypes.Contains(target.Pawn.genes.Xenotype))
				if (pawn.IsFungal(true))
				{
					if (!Rand.Chance(Props.resistanceChance))
					{
						pawn.genes.AddGene(Props.parasitismGene, true);
					}
				}
				else
				{
					if (!Props.possibleCapGenes.NullOrEmpty())
					{
						pawn.genes.AddGene(Props.possibleCapGenes.RandomElement(), true);
					}
					pawn.genes.AddGene(Props.parasitismGene, true);
				}
			}
		}
	}
}
