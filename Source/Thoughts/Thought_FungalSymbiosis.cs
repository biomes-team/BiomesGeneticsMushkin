using RimWorld;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class Thought_FungalSymbiosis : Thought_Memory
	{
		private FungalSymbiosisMapComponent mapComp;
		private FungalSymbiosisMapComponent MapComp
		{
			get
			{
				mapComp ??= pawn.MapHeld.GetComponent<FungalSymbiosisMapComponent>();
				return mapComp;
			}
		}


		public override void ThoughtInterval()
		{
			base.ThoughtInterval();
			if (MapComp.pawnsWithFungalSymbiosis.Count <= 1)
			{
				SetForcedStage(1);
			}
			else
			{
				SetForcedStage(0);
			}
		}


		public override float MoodOffset()
		{
			if (CurStageIndex == 0)
			{
				float totalMood = 0f;
				foreach (Pawn pawn in MapComp.pawnsWithFungalSymbiosis)
				{
					totalMood += pawn.needs.mood.CurLevel;
				}
				totalMood *= 10;
				return totalMood / MapComp.pawnsWithFungalSymbiosis.Count;
			}
			else
			{
				return base.MoodOffset();
			}
		}
    }
    public class ThoughtWorker_Precept_FungalSymbiosis_Social : ThoughtWorker_Precept_Social
    {
        protected override ThoughtState ShouldHaveThought(Pawn p, Pawn otherPawn)
        {
            return otherPawn.IsFungal();
        }
    }
    public class ThoughtWorker_Precept_IsFungalSymbiosis : ThoughtWorker_Precept
    {
        protected override ThoughtState ShouldHaveThought(Pawn p)
        {
            return p.IsFungal();
        }
    }
    public class ThoughtWorker_Precept_FungalSymbiosisColonist : ThoughtWorker_Precept
    {
        protected override ThoughtState ShouldHaveThought(Pawn p)
        {
            if (p.Faction == null || p.IsFungal())
            {
                return ThoughtState.Inactive;
            }
            _ = p.Ideo;
            bool flag = false;
            foreach (Pawn item in p.MapHeld.mapPawns.SpawnedPawnsInFaction(p.Faction))
            {
                if (item.IsFungal())
                {
                    flag = true;
                    Precept_Role precept_Role = item.Ideo?.GetRole(item);
                    if (precept_Role != null && precept_Role.ideo == p.Ideo && precept_Role.def == PreceptDefOf.IdeoRole_Leader)
                    {
                        return ThoughtState.ActiveAtStage(2);
                    }
                }
            }
            if (flag)
            {
                return ThoughtState.ActiveAtStage(1);
            }
            return ThoughtState.ActiveAtStage(0);
        }
    }
    public class ThoughtWorker_Precept_FungalSymbiosisPresent : ThoughtWorker_Precept
    {
        protected override ThoughtState ShouldHaveThought(Pawn p)
        {
            if (p.IsFungal())
            {
                return ThoughtState.Inactive;
            }
            foreach (Pawn item in p.MapHeld.mapPawns.AllPawnsSpawned)
            {
                if (item.IsFungal() && (item.IsPrisonerOfColony || item.IsSlaveOfColony || item.IsColonist))
                {
                    return ThoughtState.ActiveDefault;
                }
            }
            return ThoughtState.Inactive;
        }
    }
}
