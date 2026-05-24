using Game.Base.Pause;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI.Screens.DefeatScreen
{
	public class DefeatScreenView : ScreenView<DefeatScreenViewModel>
	{
		[field: SerializeField]
		private TextMeshProUGUI EnemiesRemainCount { get; set; }

		[field: SerializeField]
		private Button MainMenuButton { get; set; }

		[Inject]
		private IPauseService PauseService { get; set; }

		public override void Show()
		{
			EnemiesRemainCount.text = ViewModel.RemainEnemies.ToString();
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