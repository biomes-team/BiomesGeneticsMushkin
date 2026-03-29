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

		/// <summary>
		/// For rare check. See AbilityComp_FungalParasitism for example.
		/// </summary>
		/// <param name="p"></param>
		/// <param name="resetCollection"></param>
		/// <returns></returns>
		public static bool IsFungal(this Pawn p, bool resetCollection)
		{
			ResetCollection(resetCollection);
			return GetFungalSymbiosisPawns.Contains(p);
		}

		/// <summary>
		/// For passive checks. See ThoughtWorker_Precept_FungalSymbiosis_Social for example.
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public static bool IsFungal(this Pawn p)
		{
			//return p.genes?.GetFirstGeneOfType<Gene_FungalSymbiosis>() != null;
			return GetFungalSymbiosisPawns.Contains(p);
		}

		//public static GeneDef FungalParasit => DefDatabase<GeneDef>.AllDefsListForReading.Where((gene) => gene.geneClass == typeof(Gene_FungalParasitism)).First();

		//public static bool IsFungalParasit(this Pawn p)
		//{
		//	return p.genes?.GetFirstGeneOfType<Gene_FungalParasitism>() != null;
		//}
		public static bool HasGene(Pawn pawn, GeneDef geneDef)
		{
			if (geneDef == null || pawn.genes == null)
			{
				return false;
			}
			List<Gene> genesListForReading = pawn.genes.GenesListForReading;
			for (int i = 0; i < genesListForReading.Count; i++)
			{
				if (genesListForReading[i].def == geneDef)
				{
					return true;
				}
			}
			return false;
		}

	}

}
