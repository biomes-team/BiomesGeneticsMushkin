using RimWorld;
using UnityEngine;
using Verse;
using Verse.Noise;

namespace BiomesGeneticsMushkin
{
	public class AbilityComp_HediffGiverArea : CompAbilityEffect
	{
		public new CompProperties_HediffGiverArea Props => (CompProperties_HediffGiverArea)props;


		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{
			base.Apply(target, dest);
			ThrowEffecter();

			foreach (Pawn targetPawn in parent.pawn.Map.mapPawns.AllPawnsSpawned)
			{
				Log.Message(targetPawn);
				if (targetPawn.Position.DistanceToSquared(parent.pawn.Position) > Props.range)
				{
					continue;
				}

				if (Props.xenotypesImmuneToDebuff.Contains(target.Pawn?.genes?.Xenotype))
				{
					ApplyHediff(targetPawn, 1);
				}
				else
				{
					ApplyHediff(targetPawn, 0.1f);
				}
			}
		}


		private void ThrowEffecter()
		{
			for (int i = 0; i < 10;  i++)
			{
				if (parent.pawn.DrawPos.ToIntVec3().ShouldSpawnMotesAt(parent.pawn.Map))
				{
					FleckCreationData dataStatic = FleckMaker.GetDataStatic(parent.pawn.DrawPos + new Vector3(Rand.Range(-0.02f, 0.02f), 0f, Rand.Range(-0.02f, 0.02f)), parent.pawn.Map, Props.effecter, 1.5f);
					dataStatic.rotationRate = Rand.RangeInclusive(-240, 240);
					dataStatic.velocityAngle = Rand.Range(-45, 45);
					dataStatic.velocitySpeed = Rand.Range(1.2f, 1.5f);
					parent.pawn.Map.flecks.CreateFleck(dataStatic);
				}
			}
		}

		private void ApplyHediff(Pawn targetPawn, float stageIndex)
		{
			Hediff hd = HediffMaker.MakeHediff(Props.hediffDef, targetPawn);
			hd.Severity = stageIndex;
			targetPawn.health.AddHediff(hd);
		}
	}
}
