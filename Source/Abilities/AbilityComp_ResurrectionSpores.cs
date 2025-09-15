using RimWorld;
using System.Linq;
using Verse;

namespace BiomesGeneticsMushkin
{
	internal class AbilityComp_ResurrectionSpores : CompAbilityEffect
	{
		private static readonly SimpleCurve DementiaChancePerRotDaysCurve =
		[
			new CurvePoint(0.1f, 0.1f),
			new CurvePoint(5f, 1f)
		];

		private static readonly SimpleCurve BlindnessChancePerRotDaysCurve =
		[
			new CurvePoint(0.1f, 0.1f),
			new CurvePoint(5f, 1f)
		];

		private static readonly SimpleCurve ResurrectionPsychosisChancePerRotDaysCurve =
		[
			new CurvePoint(0.1f, 0.1f),
			new CurvePoint(5f, 1f)
		];


		public new CompProperties_ResurrectionSpores Props => (CompProperties_ResurrectionSpores)props;

		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{
			base.Apply(target, dest);
			if (target.Thing is Corpse corpse)
			{
				TryResurrectWithSideEffects(corpse.InnerPawn);

			}
		}


		private static bool TryResurrectWithSideEffects(Pawn pawn)
		{
			Corpse corpse = pawn.Corpse;
			float badOutcomeChance = (corpse == null) ? 0f : (corpse.GetComp<CompRottable>().RotProgress / 60000f);
			badOutcomeChance *= 2;

			if (!ResurrectionUtility.TryResurrect(pawn))
			{
				Log.Message("HELLO");
				return false;
			}
			AddHediffWithoutDeathRisk(pawn, HediffDefOf.ResurrectionSickness);

			BodyPartRecord brain = pawn.health.hediffSet.GetBrain();
			if (Rand.Chance(DementiaChancePerRotDaysCurve.Evaluate(badOutcomeChance)) && brain != null)
			{
				AddHediffWithoutDeathRisk(pawn, HediffDefOf.Dementia, brain);
			}
			if (Rand.Chance(BlindnessChancePerRotDaysCurve.Evaluate(badOutcomeChance)))
			{
				foreach (BodyPartRecord eye in from x in pawn.health.hediffSet.GetNotMissingParts()
											   where x.def == BodyPartDefOf.Eye
											   select x)
				{
					if (!pawn.health.hediffSet.PartOrAnyAncestorHasDirectlyAddedParts(eye))
					{
						Hediff hediff3 = HediffMaker.MakeHediff(HediffDefOf.Blindness, pawn, eye);
						pawn.health.AddHediff(hediff3);
					}
				}
			}
			if (brain != null && Rand.Chance(ResurrectionPsychosisChancePerRotDaysCurve.Evaluate(badOutcomeChance)))
			{
				AddHediffWithoutDeathRisk(pawn, HediffDefOf.ResurrectionPsychosis, brain);
			}
			if (pawn.Dead)
			{
				Log.Error("The pawn has died while being resurrected.");
				ResurrectionUtility.TryResurrect(pawn);
			}
			return true;
		}

		private static void AddHediffWithoutDeathRisk(Pawn pawn, HediffDef hediff, BodyPartRecord bodyPartRecord = null)
		{
			Hediff hd = HediffMaker.MakeHediff(hediff, pawn, bodyPartRecord);
			if (!pawn.health.WouldDieAfterAddingHediff(hd))
			{
				pawn.health.AddHediff(hd);
			}
		}
	}
}
