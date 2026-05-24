using Game.Base.Pause;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI.Screens.VictoryScreen
{
	public class VictoryScreenView : ScreenView<VictoryScreenViewModel>
	{
		[field: SerializeField]
		private TextMeshProUGUI EnemiesKilledCount { get; set; }

		[field: SerializeField]
		private Button MainMenuButton { get; set; }

		[Inject]
		private IPauseService PauseService { get; set; }

		public override void Show()
		{
			EnemiesKilledCount.text = ViewModel.KilledEnemies.ToString();
			MainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
			PauseService.PauseGame();
		}

		public override void Hide()
		{
			MainMenuButton.onClick.RemoveAllListeners();
			PauseService.UnpauseGame();
		}

		private void OnMainMenuButtonClicked()
		{
			ViewModel.LoadMainMenu();
		}
	}
}