using Game.Base.Application;
using Game.Base.Pause;
using Game.Base.UI;
using Zenject;

namespace Game.UI.Screens.PauseScreen
{
	public class PauseScreenViewModel : ScreenViewModel
	{
		[Inject]
		private IApplication Application { get; set; }

		[Inject]
		private IPauseService PauseService { get; set; }

		[Inject]
		private IUiSystem UiSystem { get; set; }

		public override void Initialize()
		{
			PauseService.PauseGame();
		}

		public void ContinueGame()
		{
			UiSystem.ShowScreen(ScreenType.Hud);
			PauseService.UnpauseGame();
		}

		public void LoadMainMenu()
		{
			Application.LoadMainMenu();
			PauseService.UnpauseGame();
		}
	}
}