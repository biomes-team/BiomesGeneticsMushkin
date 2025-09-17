using RimWorld;
using Verse;

namespace BiomesGeneticsMushkin
{
	[DefOf]
	internal static class DefOfs
	{
		static DefOfs()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(DefOfs));
		}

		public static XenotypeDef BGM_Mushkin;
		public static HediffDef BGM_FungalUndead;
	}
}
