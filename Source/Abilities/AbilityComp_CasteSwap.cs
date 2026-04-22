using RimWorld;
using System;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class AbilityComp_CasteSwap : CompAbilityEffect
	{
		public XenotypeDef pickedCaste;
		public new CompProperties_CasteSwap Props => (CompProperties_CasteSwap)props;


		public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
		{
			//if (target.Pawn?.genes is null) return false;

			//if (!Props.allowedXenotypes.Contains(target.Pawn.genes.Xenotype)) return false;

			Pawn pawn = target.Pawn;
			if (pawn?.genes != null && (pawn.IsFungal(false) || Props.allowedXenotypes.Contains(target.Pawn.genes.Xenotype)))
			{
				return base.Valid(target, throwMessages);
			}
			return false;
		}


		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{
			base.Apply(target, dest);
			Pawn pawn = target.Pawn;
			if (pawn == null || pickedCaste == null)
			{
				return;
			}
			bool isParasit = Props.parasitismGene != null && pawn.genes.HasActiveGene(Props.parasitismGene);
			pawn.genes.SetXenotype(pickedCaste);
			if (isParasit)
			{
				pawn.genes.AddGene(Props.parasitismGene, true);
			}
			pawn.health?.AddHediff(Props.hediffToGive);
		}


		public override Window ConfirmationDialog(LocalTargetInfo target, Action confirmAction)
		{
			return new Window_PickCaste(this, confirmAction);
		}
	}
}
