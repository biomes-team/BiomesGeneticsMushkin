using RimWorld;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class AbilityComp_FungalReanimation : CompAbilityEffect
	{
		public new CompProperties_FungalReanimation Props => (CompProperties_FungalReanimation)props;


		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{
			base.Apply(target, dest);
			if (target.Thing is Corpse corpse)
			{
				Pawn ressedPawn = corpse.InnerPawn;
				ResurrectionUtility.TryResurrect(ressedPawn);
				if (ressedPawn.Faction != parent.pawn?.Faction)
				{
					ressedPawn.SetFaction(parent.pawn.Faction);
				}
				ressedPawn.genes?.AddGene(Props.reanimationGene, true);
			}
		}

		public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
		{
			if (target.HasThing && target.Thing is Corpse corpse && corpse.GetRotStage() == RotStage.Dessicated)
			{
				if (throwMessages)
				{
					Messages.Message("MessageCannotResurrectDessicatedCorpse".Translate(), corpse, MessageTypeDefOf.RejectInput, historical: false);
				}
				return false;
			}
			return base.Valid(target, throwMessages);
		}

	}
}
