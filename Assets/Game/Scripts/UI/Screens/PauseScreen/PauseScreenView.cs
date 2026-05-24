using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Screens.PauseScreen
{
	public class PauseScreenView : ScreenView<PauseScreenViewModel>
	{
		[field: SerializeField]
		private Button ContinueButton { get; set; }

		[field: SerializeField]
		private Button MainMenuButton { get; set; }

		public override void Show()
		{
			ContinueButton.onClick.AddListener(OnContinueButtonClicked);
			MainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
		}

		public override void Hide()
		{
			ContinueButton.onClick.RemoveAllListeners();
			MainMenuButton.onClick.RemoveAllListeners();
		}

		private void OnContinueButtonClicked()
		{
			ViewModel.ContinueGame();
		}

		private void OnMainMenuButtonClicked()
		{
			ViewModel.LoadMainMenu();
		}
	}
}