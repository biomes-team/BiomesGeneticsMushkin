using HarmonyLib;
using Verse;

namespace BiomesGeneticsMushkin
{
	[StaticConstructorOnStartup]
	public static class HarmonyInit
	{
		static HarmonyInit()
		{
			Harmony harmony = new("BiomesTeam.BiomesGeneticsMushkin");
			harmony.PatchAll();
		}
	}
}
