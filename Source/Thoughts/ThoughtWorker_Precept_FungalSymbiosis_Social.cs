using RimWorld;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class ThoughtWorker_Precept_FungalSymbiosis_Social : ThoughtWorker_Precept_Social
	{
		protected override ThoughtState ShouldHaveThought(Pawn p, Pawn otherPawn)
		{
			return otherPawn.IsFungal();
		}
	}
}
