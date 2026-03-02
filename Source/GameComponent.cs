using Verse;

namespace BiomesGeneticsMushkin
{
	public class BGM_GameComponent : GameComponent
	{

		public Game currentGame;

		public BGM_GameComponent(Game game)
		{
			currentGame = game;
		}

		public override void StartedNewGame()
		{
			GeneralUtility.ResetCollection();
		}

		public override void LoadedGame()
		{
			GeneralUtility.ResetCollection();
		}

	}

}
