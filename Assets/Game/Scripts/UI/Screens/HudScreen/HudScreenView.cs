using Game.UI.Screens.HudScreen.Views;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.UI.Screens.HudScreen
{
	public class HudScreenView : ScreenView<HudScreenViewModel>
	{
		[field: SerializeField]
		private InputActionReference PauseInputAction { get; set; }

		[field: SerializeField]
		private TextMeshProUGUI PlayerHealth { get; set; }

		[field: SerializeField]
		private AttackInfoView BaseAttackInfo { get; set; }

		[field: SerializeField]
		private AttackInfoView SpecialAttackInfo { get; set; }

		[field: SerializeField]
		private PlayerAbilitiesView PlayerAbilitiesView { get; set; }

		public override void Show()
		{
			PauseInputAction.action.performed += OnPausePerformed;
			PauseInputAction.action.Enable();

			BaseAttackInfo.Initialize(ViewModel.BasePlayerAttack);
			SpecialAttackInfo.Initialize(ViewModel.SpecialPlayerAttack);
			PlayerAbilitiesView.Initialize(ViewModel.PlayerAbilities);

			ViewModel.EventPlayerHealthChanged += OnPlayerHealthChanged;
			OnPlayerHealthChanged();
		}

		public override void Hide()
		{
			ViewModel.EventPlayerHealthChanged -= OnPlayerHealthChanged;
			PauseInputAction.action.performed -= OnPausePerformed;
			PauseInputAction.action.Disable();
		}

		private void OnPausePerformed(InputAction.CallbackContext _)
		{
			ViewModel.PauseGame();
		}

		private void OnPlayerHealthChanged()
		{
			PlayerHealth.text = $"{ViewModel.PlayerHealth}";
		}
	}
}