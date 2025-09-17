using RimWorld;
using Verse;

namespace BiomesGeneticsMushkin
{
	public class AbilityComp_BuddingBirth : CompAbilityEffect
	{
		public new CompProperties_BuddingBirth Props => (CompProperties_BuddingBirth)props;


		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{
			base.Apply(target, dest);
			Pawn babyClone = BuddingBirthCloner.Clone(parent.pawn);
			GenSpawn.Spawn(babyClone, parent.pawn.Position, parent.pawn.Map);
		}
	}
}
