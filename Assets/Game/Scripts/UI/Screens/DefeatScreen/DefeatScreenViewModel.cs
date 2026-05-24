using Game.Base.Application;
using Game.UI.Extensions;
using Zenject;

namespace Game.UI.Screens.DefeatScreen
{
	public class DefeatScreenViewModel : ScreenViewModel
	{
		[Inject]
		private IApplication Application { get; set; }

		public int RemainEnemies => Application.GetGameController().EnemyBehaviours.Count;

		public void LoadMainMenu()
		{
			Application.LoadMainMenu();
		}
	}
}