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
			if (target.Pawn is not null && target.Pawn.genes is not null)
			{
				if (Props.resistantXenotypes.Contains(target.Pawn.genes.Xenotype))
				{
					if (!Rand.Chance(Props.resistanceChance))
					{
						target.Pawn.genes.AddGene(Props.parasitismGene, true);
					}
				}
				else
				{
					target.Pawn.genes.AddGene(Props.parasitismGene, true);
				}
			}
		}
	}
}
