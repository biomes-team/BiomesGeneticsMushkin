using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace BiomesGeneticsMushkin
{
    public static class GeneralUtility
    {

        public static bool IsFungal(this Pawn p)
        {
            return p.genes?.GetFirstGeneOfType<Gene_FungalSymbiosis>() != null;
        }

    }

}
