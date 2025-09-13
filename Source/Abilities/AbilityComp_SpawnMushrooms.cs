using RimWorld;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class AbilityComp_SpawnMushrooms : CompAbilityEffect
	{
		public new CompProperties_SpawnMushrooms Props => (CompProperties_SpawnMushrooms)props;


		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{
			base.Apply(target, dest);
			var cells = GenRadial.RadialCellsAround(parent.pawn.Position, Props.range, true);

			foreach (var cell in cells)
			{
				GenSpawn.Spawn(Props.plantsToSpawn.RandomElement(), cell, parent.pawn.Map);
			}
		}
	}
}
