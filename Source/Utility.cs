using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace BiomesGeneticsMushkin
{
	public static class GeneralUtility
	{

		private static List<Pawn> fungalSymbiosisPawns = null;
		private static List<Pawn> fungalSymbiosisPawns_Player = null;

		private static int lastRecacheTick = -1;

		public static void ResetCollection(bool forcedRacache)
		{
			if (forcedRacache || lastRecacheTick <= Find.TickManager.TicksGame + 60000)
			{
				fungalSymbiosisPawns = null;
				fungalSymbiosisPawns_Player = null;
				lastRecacheTick = Find.TickManager.TicksGame;
			}
		}

		public static List<Pawn> GetFungalSymbiosisPawns
		{
			get
			{
				if (fungalSymbiosisPawns == null)
				{
					fungalSymbiosisPawns = PawnsFinder.AllMapsAndWorld_Alive.Where((fungus) => fungus.genes?.GetFirstGeneOfType<Gene_FungalSymbiosis>() != null).ToList();
				}
				return fungalSymbiosisPawns;
			}
		}

		public static List<Pawn> GetFungalSymbiosisPawns_Player
		{
			get
			{
				if (fungalSymbiosisPawns_Player == null)
				{
					fungalSymbiosisPawns_Player = GetFungalSymbiosisPawns.Where((fungus) => fungus.Faction == Faction.OfPlayerSilentFail).ToList();
				}
				return fungalSymbiosisPawns_Player;
			}
		}

		public static bool IsFungal(this Pawn p)
		{
			//return p.genes?.GetFirstGeneOfType<Gene_FungalSymbiosis>() != null;
			return GetFungalSymbiosisPawns.Contains(p);
		}

	}

}
