using System;
using System.Collections.Generic;
using Game.Base.Application;
using Game.Base.UI;
using Game.Core.Ability;
using Game.Core.Player;
using Game.Core.Player.Attack;
using Game.UI.Extensions;
using Zenject;

namespace Game.UI.Screens.HudScreen
{
	public class HudScreenViewModel : ScreenViewModel
	{
		[Inject]
		private IUiSystem UiSystem { get; set; }

		[Inject]
		private IApplication Application { get; set; }

		public event Action EventPlayerHealthChanged;

		public int PlayerHealth => (int)PlayerBehaviour.Health;

		public AttackBehaviourBase BasePlayerAttack => PlayerBehaviour.BaseAttack;
		public AttackBehaviourBase SpecialPlayerAttack => PlayerBehaviour.SpecialAttack;

		public List<AbilityBase> PlayerAbilities => PlayerBehaviour.Abilities;

		private PlayerBehaviour PlayerBehaviour => Application.GetGameController().PlayerBehaviour;
		
		public override void Initialize()
		{
			PlayerBehaviour.EventHealthChanged += OnPlayerHealthChanged;
		}

		public override void Close()
		{
			PlayerBehaviour.EventHealthChanged -= OnPlayerHealthChanged;
		}

		public void PauseGame()
		{
			UiSystem.ShowScreen(ScreenType.Pause);
		}

		private void OnPlayerHealthChanged()
		{
			EventPlayerHealthChanged?.Invoke();
		}
	}
}