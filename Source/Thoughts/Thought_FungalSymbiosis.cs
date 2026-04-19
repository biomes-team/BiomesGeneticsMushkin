using RimWorld;
using System;
using System.Collections.Generic;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class Thought_FungalSymbiosis : Thought_Memory
	{
		//private FungalSymbiosisMapComponent mapComp;
		//private FungalSymbiosisMapComponent MapComp
		//{
		//	get
		//	{
		//		mapComp ??= pawn.MapHeld.GetComponent<FungalSymbiosisMapComponent>();
		//		return mapComp;
		//	}
		//}
		public override bool ShouldDiscard => disabled;

		private static List<Pawn> SymbiosisPawns_Player => GeneralUtility.GetFungalSymbiosisPawns_Player;


		public override void ThoughtInterval()
		{
			base.ThoughtInterval();
			if (SymbiosisPawns_Player.Count <= 1)
			{
				SetForcedStage(1);
			}
			else
			{
				SetForcedStage(0);
			}
		}

		private bool disabled = false;
		public override float MoodOffset()
		{
			if (disabled)
			{
				return 0f;
			}
			try
			{
				if (SymbiosisPawns_Player.Contains(pawn))
				{
					if (CurStageIndex == 0)
					{
						float totalMood = 0f;
						foreach (Pawn pawn in SymbiosisPawns_Player)
						{
							totalMood += pawn.needs.mood.CurLevel;
						}
						totalMood *= 10;
						return totalMood / SymbiosisPawns_Player.Count;
					}
					return base.MoodOffset();
				}
			}
			catch (Exception arg)
			{
				disabled = true;
				// Non-critical error. Warning catch.
				Log.Warning("Failed offset mood for pawn: " + (pawn?.Name).ToStringSafe() + ". Removing thought. Reason: " + arg.Message);
			}
			return 0;
		}
	}
}
