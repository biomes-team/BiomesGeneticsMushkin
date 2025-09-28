using RimWorld;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class Gene_FungalSymbiosis : Gene
	{
		private FungalSymbiosisMapComponent mapComp;
		private ModExtension modExtension;
		private ModExtension ModExtension
		{
			get
			{
				modExtension ??= def.GetModExtension<ModExtension>();
				return modExtension;
			}
		}
		private FungalSymbiosisMapComponent MapComp
		{
			get
			{
				mapComp ??= pawn.Map.GetComponent<FungalSymbiosisMapComponent>();
				return mapComp;
			}
		}


		public override void PostAdd()
		{
			base.PostAdd();
			MapComp.pawnsWithFungalSymbiosis.AddDistinct(pawn);
			Thought_FungalSymbiosis thought = (Thought_FungalSymbiosis)ThoughtMaker.MakeThought(ModExtension.symbiosisThought);
			thought.permanent = true;
			pawn.needs?.mood?.thoughts?.memories?.TryGainMemory(thought);
		}


		public override void PostRemove()
		{
			base.PostRemove();
			MapComp.pawnsWithFungalSymbiosis.Remove(pawn);
			pawn.needs?.mood?.thoughts?.memories?.RemoveMemoriesOfDef(ModExtension.symbiosisThought);
		}
	}
}
