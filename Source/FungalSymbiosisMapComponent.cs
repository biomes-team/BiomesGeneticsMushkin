using System.Collections.Generic;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class FungalSymbiosisMapComponent : MapComponent
	{
		public FungalSymbiosisMapComponent(Map map) : base(map) { }

		public List<Pawn> pawnsWithFungalSymbiosis = [];
	}
}
