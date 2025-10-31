using RimWorld;
using Verse;

namespace BiomesGeneticsMushkin
{
#pragma warning disable CS0649
	[DefOf]
	internal static class DefOfs
	{
		static DefOfs()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(DefOfs));
		}

		public static XenotypeDef BGM_Mushkin;
		public static XenotypeDef BGM_Sovereign;
		public static HediffDef BGM_FungalUndead;
		public static HediffDef BGM_FungalParasite;
	}
}
