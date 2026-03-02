using RimWorld;
using Verse;

namespace BiomesGeneticsMushkin
{
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
			return flag ? ThoughtState.ActiveAtStage(1) : ThoughtState.ActiveAtStage(0);
		}
	}
}
