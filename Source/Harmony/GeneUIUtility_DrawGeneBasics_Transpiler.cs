using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using Verse;

namespace BiomesGeneticsMushkin
{
	[HarmonyPatch(typeof(GeneUIUtility), "DrawGeneBasics")]
	internal class GeneUIUtility_DrawGeneBasics_Transpiler
	{
		private static readonly CachedTexture MushkinBackground = new("UI/Xenotype/GeneBackground_Mushkin");


		private static void ChangeGeneBackground(GeneDef gene, ref CachedTexture texture)
		{
			Log.Message("Went in");
			if (gene.geneClass.SameOrSubclassOf<MushkinGene>())
			{
				Log.Message("Is of type");
				Log.Message("Texture should be changed");
				Log.Message(texture.Texture.ToString());
				Log.Message(MushkinBackground.Texture.ToString());
				texture = MushkinBackground;
				Log.Message(texture.Texture.ToString());
				Log.Message(MushkinBackground.Texture.ToString());
			}
		}


		[HarmonyTranspiler]
		internal static IEnumerable<CodeInstruction> AddCustomBackground(IEnumerable<CodeInstruction> codeInstructions)
		{
			CodeMatcher codeMatcher = new(codeInstructions);

			var instructionsToMatch = new CodeMatch[]
			{
				new(OpCodes.Ldloc_2),
				new(OpCodes.Ldloc_S),
				new(OpCodes.Callvirt, AccessTools.PropertyGetter(typeof(CachedTexture), nameof(CachedTexture.Texture))),
				new(OpCodes.Call, AccessTools.Method(typeof(GUI), nameof(GUI.DrawTexture),[typeof(Rect), typeof(Texture)]))
			};

			var instructionsToInsert = new CodeInstruction[]
			{
				new(OpCodes.Ldarg_0),
				new(OpCodes.Ldloca_S, 4),
				new(OpCodes.Call, AccessTools.Method(typeof(GeneUIUtility_DrawGeneBasics_Transpiler), nameof(ChangeGeneBackground)))
			};

			codeMatcher.MatchStartForward(instructionsToMatch);

			if (codeMatcher.IsInvalid)
			{
				Log.Error("Biomes genetics mushkin couldn't transpile GeneUIUtility.DrawGeneBasics. Report it on steam.");
				return codeInstructions;
			}
			else
			{
				codeMatcher.Insert(instructionsToInsert);
				foreach (var instruction in codeMatcher.InstructionEnumeration())
				{
					Log.Message(instruction.ToString());
				}
				return codeMatcher.InstructionEnumeration();
			}
		}
	}
}
