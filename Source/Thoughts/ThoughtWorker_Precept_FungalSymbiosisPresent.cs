using RimWorld;
using Verse;

namespace BiomesGeneticsMushkin
{
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
