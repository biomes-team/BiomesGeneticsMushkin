using RimWorld;
using System;
using System.Collections.Generic;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class AbilityComp_CasteSwap : CompAbilityEffect
	{
		public XenotypeDef pickedCaste;
		public new CompProperties_CasteSwap Props => (CompProperties_CasteSwap)props;


		public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
		{
			if (target.Pawn?.genes is null) return false;

			if (!Props.allowedXenotypes.Contains(target.Pawn.genes.Xenotype)) return false;

			return base.Valid(target, throwMessages);
		}


		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{
			base.Apply(target, dest);
			target.Pawn.genes.SetXenotype(pickedCaste);
			target.Pawn.health?.AddHediff(Props.hediffToGive);
		}


		public override Window ConfirmationDialog(LocalTargetInfo target, Action confirmAction)
		{
			return new Window_PickCaste(this, confirmAction);
		}
	}
}
