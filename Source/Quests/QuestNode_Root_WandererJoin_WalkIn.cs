using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace BiomesGeneticsMushkin
{

    public class IncidentWorker_GiveQuest_Sovereign : IncidentWorker_GiveQuest
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            // The check is tied to the xenotype and not genes, so that the chance of obtaining is strictly tied to a specific playstyle.
            List<Pawn> list = PawnsFinder.AllMapsCaravansAndTravellingTransporters_Alive_Colonists;
            return list.Any((pawn) => pawn.genes?.Xenotype == DefOfs.BGM_Mushkin) && !list.Any((pawn) => pawn.genes?.Xenotype == DefOfs.BGM_Sovereign);
        }

        public override float ChanceFactorNow(IIncidentTarget target)
        {
            return 1f;
        }
    }

    public class QuestNode_Root_WandererJoin_WalkIn : RimWorld.QuestGen.QuestNode_Root_WandererJoin_WalkIn
    {

        public XenotypeDef xenotypeDef;

        public override Pawn GeneratePawn()
        {
            Pawn pawn = base.GeneratePawn();
            if (xenotypeDef != null)
            {
                Pawn_GeneTracker genes = pawn.genes;
                genes.SetXenotype(xenotypeDef);
                foreach (Gene xenogene in genes.Xenogenes.ToList())
                {
                    genes.RemoveGene(xenogene);
                }
                foreach (GeneDef xenogene in xenotypeDef.genes)
                {
                    genes.AddGene(xenogene, xenogene: true);
                }
            }
            return pawn;
        }

    }

}
