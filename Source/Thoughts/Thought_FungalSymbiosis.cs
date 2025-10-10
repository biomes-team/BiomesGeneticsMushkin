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
}
