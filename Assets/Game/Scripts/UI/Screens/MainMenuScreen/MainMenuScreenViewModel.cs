using Cysharp.Threading.Tasks;
using Game.Base.Application;
using Zenject;

namespace Game.UI.Screens.MainScreen
{
	public class MainMenuScreenViewModel : ScreenViewModel
	{
		[Inject]
		private IApplication Application { get; set; }

		public void StartGame()
		{
			Application.StartGame().Forget();
		}

		public void Quit()
		{
			Application.Quit();
		}
	}
}