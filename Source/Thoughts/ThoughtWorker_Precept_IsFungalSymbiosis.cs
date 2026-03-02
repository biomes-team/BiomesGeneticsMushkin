using RimWorld;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class ThoughtWorker_Precept_IsFungalSymbiosis : ThoughtWorker_Precept
	{
		protected override ThoughtState ShouldHaveThought(Pawn p)
		{
			return p.IsFungal();
		}
	}
}
