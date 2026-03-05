using RimWorld;

namespace BiomesGeneticsMushkin
{
	public class Gene_FungalSymbiosis : MushkinGene
	{
		//private FungalSymbiosisMapComponent mapComp;
		private ModExtension modExtension;
		private ModExtension ModExtension
		{
			get
			{
				modExtension ??= def.GetModExtension<ModExtension>();
				return modExtension;
			}
		}
		//private FungalSymbiosisMapComponent MapComp
		//{
		//	get
		//	{
		//		mapComp ??= pawn.Map.GetComponent<FungalSymbiosisMapComponent>();
		//		return mapComp;
		//	}
		//}

		private int nextTick = 120;
		public override void TickInterval(int delta)
		{
			nextTick -= delta;
			if (nextTick > 0)
			{
				return;
			}
			nextTick = 60002;
			Update(false);
		}


		public override void PostAdd()
		{
			base.PostAdd();
			//if (pawn.Spawned)
			//{
			//	//MapComp.pawnsWithFungalSymbiosis.AddDistinct(pawn);
			//}
			Update(true);
		}

		private void Update(bool forcedRacache)
		{
			GeneralUtility.ResetCollection(forcedRacache);
			Thought_FungalSymbiosis thought = (Thought_FungalSymbiosis)ThoughtMaker.MakeThought(ModExtension.symbiosisThought);
			thought.permanent = true;
			pawn.needs?.mood?.thoughts?.memories?.TryGainMemory(thought);
		}

		public override void PostRemove()
		{
			base.PostRemove();
			//if (pawn.Spawned)
			//{
			//	//MapComp.pawnsWithFungalSymbiosis.Remove(pawn);
			//}
			pawn.needs?.mood?.thoughts?.memories?.RemoveMemoriesOfDef(ModExtension.symbiosisThought);
			GeneralUtility.ResetCollection(true);
		}
	}
}
