using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Screens.MainScreen
{
	public class MainMenuScreenView : ScreenView<MainMenuScreenViewModel>
	{
		[field: SerializeField]
		private Button StartButton { get; set; }

		[field: SerializeField]
		private Button QuitButton { get; set; }

		public override void Show()
		{
			StartButton.onClick.AddListener(OnStartButtonClicked);
			QuitButton.onClick.AddListener(OnQuitButtonClicked);
		}

		public override void Hide()
		{
			StartButton.onClick.RemoveAllListeners();
			QuitButton.onClick.RemoveAllListeners();
		}

		private void OnStartButtonClicked()
		{
			ViewModel.StartGame();
		}

		private void OnQuitButtonClicked()
		{
			ViewModel.Quit();
		}
	}
}