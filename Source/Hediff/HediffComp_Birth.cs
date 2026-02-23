using RimWorld;
using RimWorld.Planet;
using System.Linq;
using Verse;
using Verse.AI.Group;
using Verse.Sound;
using static RimWorld.RitualStage_InteractWithRole;

namespace BiomesGeneticsMushkin
{
	public class HediffComp_Birth : HediffComp
	{
		public HediffCompProperties_Birth Props => (HediffCompProperties_Birth)props;


		public override void CompPostPostAdd(DamageInfo? dinfo)
		{
            //base.CompPostPostAdd(dinfo);
            //Pawn babyClone = Find.PawnDuplicator.Duplicate(parent.pawn);
            //AdjustClone(babyClone);
            //GenSpawn.Spawn(babyClone, parent.pawn.Position, parent.pawn.Map);
            TrySpawnHatchedOrBornPawn(parent.pawn, parent.pawn, NewBornRequest(parent.pawn.kindDef, parent.pawn.Faction), DefOfs.BGM_Mushkin);
        }


        //private static void AdjustClone(Pawn clone)
        //{
        //	clone.ageTracker.AgeBiologicalTicks = 0;
        //	clone.genes.SetXenotype(DefOfs.BGM_Mushkin);
        //      }

        public static PawnGenerationRequest NewBornRequest(PawnKindDef pawnKind, Faction faction)
        {
            return new(pawnKind, faction, PawnGenerationContext.NonPlayer, -1, forceGenerateNewPawn: false, allowDead: false, allowDowned: true, canGeneratePawnRelations: false, mustBeCapableOfViolence: false, 1f, forceAddFreeWarmLayerIfNeeded: false, allowGay: true, allowPregnant: false, allowFood: false, allowAddictions: false, inhabitant: false, certainlyBeenInCryptosleep: false, forceRedressWorldPawnIfFormerColonist: false, worldPawnFactionDoesntMatter: false, 0f, 0f, null, 1f, null, null, null, null, null, null, null, null, null, null, null, null, forceNoIdeo: false, forceNoBackstory: false, forbidAnyTitle: false, forceDead: false, null, null, null, null, null, 0f, DevelopmentalStage.Newborn);
        }

        public static void TrySpawnHatchedOrBornPawn(Pawn parent, Thing motherOrEgg, PawnGenerationRequest generateNewBornPawn, XenotypeDef xenotypeDef = null)
        {
            Pawn newBorn = PawnGenerator.GeneratePawn(generateNewBornPawn);
            if (xenotypeDef != null)
            {
                //foreach (Gene item in newBorn.genes.GenesListForReading.ToList())
                //{
                //    newBorn.genes.RemoveGene(item);
                //}
                newBorn.genes.SetXenotype(xenotypeDef);
                //foreach (GeneDef item in xenotypeDef.genes)
                //{
                //    newBorn.genes.AddGene(item, !xenotypeDef.inheritable);
                //}
            }
            if (PawnUtility.TrySpawnHatchedOrBornPawn(newBorn, motherOrEgg))
            {
                if (parent != null)
                {
                    if (newBorn.playerSettings != null && parent.playerSettings != null)
                    {
                        newBorn.playerSettings.AreaRestrictionInPawnCurrentMap = parent.playerSettings.AreaRestrictionInPawnCurrentMap;
                    }
                    if (newBorn.RaceProps.IsFlesh)
                    {
                        newBorn.relations.AddDirectRelation(PawnRelationDefOf.Parent, parent);
                    }
                    if (parent.Spawned)
                    {
                        parent.GetLord()?.AddPawn(newBorn);
                    }
                    TaleRecorder.RecordTale(TaleDefOf.GaveBirth, parent, newBorn);
                }
            }
            else
            {
                Find.WorldPawns.PassToWorld(newBorn, PawnDiscardDecideMode.Discard);
            }
            if (newBorn.Spawned)
            {
                FilthMaker.TryMakeFilth(newBorn.Position, newBorn.Map, ThingDefOf.Filth_Slime, 5);
                DefOfs.Hive_Spawn.PlayOneShot(new TargetInfo(newBorn));
            }
            if (PawnUtility.ShouldSendNotificationAbout(newBorn))
            {
                Find.LetterStack.ReceiveLetter("Birth".Translate(), "MessageGaveBirth".Translate(motherOrEgg.LabelShortCap.Colorize(ColoredText.NameColor)), LetterDefOf.NeutralEvent, new LookTargets(newBorn));
            }
        }
    }
}
