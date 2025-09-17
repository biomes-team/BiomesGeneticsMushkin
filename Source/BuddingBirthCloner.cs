using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace BiomesGeneticsMushkin
{
	internal static class BuddingBirthCloner
	{
		public static Pawn Clone(Pawn pawn)
		{
			PawnKindDef kindDef = pawn.kindDef;
			Faction faction = pawn.Faction;
			Gender? fixedGender = pawn.gender;
			float? fixedBiologicalAge = 0;
			float? fixedChronologicalAge = 0;
			XenotypeDef xenotype = DefOfs.BGM_Mushkin;
			CustomXenotype customXenotype = pawn.genes.CustomXenotype;
			PawnGenerationRequest request = new(
				kindDef,
				faction,
				PawnGenerationContext.NonPlayer,
				null,
				forceGenerateNewPawn: true,
				allowDead: false,
				allowDowned: true,
				canGeneratePawnRelations: true,
				mustBeCapableOfViolence: false,
				0f,
				forceAddFreeWarmLayerIfNeeded: false,
				allowGay: true,
				allowPregnant: false,
				allowFood: true,
				allowAddictions: true,
				inhabitant: false,
				certainlyBeenInCryptosleep: false,
				forceRedressWorldPawnIfFormerColonist: false,
				worldPawnFactionDoesntMatter: false,
				0f,
				0f,
				null,
				0f,
				null,
				null,
				null,
				null,
				null,
				fixedBiologicalAge,
				fixedChronologicalAge,
				fixedGender,
				null,
				null,
				null,
				null,
				forceNoIdeo: true,
				forceNoBackstory: false,
				forbidAnyTitle: true,
				forceDead: false,
				null,
				null,
				xenotype,
				customXenotype,
				null,
				0f,
				DevelopmentalStage.Baby,
				null,
				null,
				null,
				forceRecruitable: false,
				dontGiveWeapon: false,
				onlyUseForcedBackstories: false,
				-1,
				0,
				forceNoGear: true)
			{
				IsCreepJoiner = pawn.IsCreepJoiner,
				ForceNoIdeoGear = true,
				CanGeneratePawnRelations = false,
				DontGivePreArrivalPathway = true
			};
			Pawn baby = PawnGenerator.GeneratePawn(request);
			baby.Name = NameTriple.FromString(pawn.Name.ToString());
			if (ModsConfig.BiotechActive)
			{
				baby.ageTracker.growthPoints = 0;
				baby.ageTracker.vatGrowTicks = 0;
				baby.genes.xenotypeName = pawn.genes.xenotypeName;
				baby.genes.iconDef = pawn.genes.iconDef;
			}
			CopyGenes(pawn, baby);
			CopyApperance(pawn, baby);
			CopyStyle(pawn, baby);
			CopySkills(pawn, baby);
			if (pawn.mutant != null)
			{
				MutantUtility.SetPawnAsMutantInstantly(baby, pawn.mutant.Def, pawn.GetRotStage());
			}
			if (pawn.guest != null)
			{
				baby.guest.Recruitable = pawn.guest.Recruitable;
			}
			baby.Drawer.renderer.SetAllGraphicsDirty();
			baby.Notify_DisabledWorkTypesChanged();
			baby.relations.AddDirectRelation(PawnRelationDefOf.Parent, pawn);
			return baby;
		}

		private static void CopyGenes(Pawn pawn, Pawn newPawn)
		{
			newPawn.genes.Endogenes.Clear();
			List<GeneDef> inheritedGermlines = PregnancyUtility.GetInheritedGenes(pawn, pawn, out _);
			foreach (GeneDef gene in inheritedGermlines)
			{
				newPawn.genes.AddGene(gene, xenogene: false);
			}
		}

		private static void CopyApperance(Pawn pawn, Pawn newPawn)
		{
			newPawn.story.hairDef = pawn.story.hairDef;
			newPawn.story.HairColor = pawn.story.HairColor;
			newPawn.story.SkinColorBase = pawn.story.SkinColorBase;
			newPawn.story.skinColorOverride = pawn.story.skinColorOverride;
			newPawn.story.furDef = pawn.story.furDef;
		}

		private static void CopyStyle(Pawn pawn, Pawn newPawn)
		{
			newPawn.style.beardDef = pawn.style.beardDef;
			if (ModsConfig.IdeologyActive)
			{
				newPawn.style.BodyTattoo = pawn.style.BodyTattoo;
				newPawn.style.FaceTattoo = pawn.style.FaceTattoo;
			}
		}

		private static void CopySkills(Pawn pawn, Pawn newPawn)
		{
			newPawn.skills.skills.Clear();
			foreach (SkillRecord skill in pawn.skills.skills)
			{
				SkillRecord item = new(newPawn, skill.def)
				{
					levelInt = skill.levelInt,
					passion = skill.passion,
					xpSinceLastLevel = skill.xpSinceLastLevel,
					xpSinceMidnight = skill.xpSinceMidnight
				};
				newPawn.skills.skills.Add(item);
			}
		}
	}
}
