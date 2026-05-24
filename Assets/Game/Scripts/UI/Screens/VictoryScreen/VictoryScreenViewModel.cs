using Game.Base.Application;
using Game.UI.Extensions;
using Zenject;

namespace Game.UI.Screens.VictoryScreen
{
	public class VictoryScreenViewModel : ScreenViewModel
	{
		[Inject]
		private IApplication Application { get; set; }

		public int KilledEnemies => Application.GetGameController().KilledEnemies;

		public void LoadMainMenu()
		{
			Application.LoadMainMenu();
		}
	}
}