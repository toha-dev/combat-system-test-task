using System;
using System.Collections.Generic;
using System.Linq;
using Game.Base.UI;
using Game.UI.Screens;
using Game.UI.Screens.DefeatScreen;
using Game.UI.Screens.HudScreen;
using Game.UI.Screens.LoadingScreen;
using Game.UI.Screens.MainScreen;
using Game.UI.Screens.PauseScreen;
using Game.UI.Screens.VictoryScreen;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Game.UI.System
{
	public class SimpleUiSystem : MonoBehaviour, IUiSystem
	{
		[Serializable]
		private class Screen
		{
			[field: SerializeField]
			public ScreenType Type { get; private set; }

			[field: SerializeField]
			public BaseScreenView ScreenView { get; private set; }
		}

		[field: SerializeField]
		private List<Screen> ScreensPool { get; set; }

		private readonly Dictionary<ScreenType, Type> _screenToViewModeTypes = new()
		{
			{ ScreenType.Loading, typeof(LoadingScreenViewModel) },
			{ ScreenType.MainMenu, typeof(MainMenuScreenViewModel) },
			{ ScreenType.Hud, typeof(HudScreenViewModel) },
			{ ScreenType.Defeat, typeof(DefeatScreenViewModel) },
			{ ScreenType.Victory, typeof(VictoryScreenViewModel) },
			{ ScreenType.Pause, typeof(PauseScreenViewModel) },
		};

		[Inject]
		private DiContainer Container { get; set; }

		[CanBeNull]
		private BaseScreenView ActiveScreen { get; set; }

		public void ShowScreen(ScreenType type)
		{
			var screen = ScreensPool.First(x => x.Type == type).ScreenView;

			if (ActiveScreen != null)
			{
				ActiveScreen.Hide();
				ActiveScreen.gameObject.SetActive(false);
				ActiveScreen.BaseViewModel.Close();
			}

			var viewModel = (ScreenViewModel)Activator.CreateInstance(_screenToViewModeTypes[type]);
			Container.Inject(viewModel);
			viewModel.Initialize();
			screen.Initialize(viewModel);

			screen.Show();
			screen.gameObject.SetActive(true);

			ActiveScreen = screen;
		}
	}
}