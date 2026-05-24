using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Base.Session;
using Game.Base.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Base.Application
{
	public class Application : IApplication, IDisposable
	{
		private const string MainMenuSceneName = "MainMenu";
		private const string GameSceneName = "Game";

		[Inject]
		private IUiSystem UiSystem { get; set; }

		public IGameSession ActiveSession { get; private set; }

		private CancellationTokenSource CancellationTokenSource { get; set; } = new();

		public void RegisterSession(IGameSession gameSession)
		{
			ActiveSession = gameSession;
		}

		public async UniTask StartGame()
		{
			UiSystem.ShowScreen(ScreenType.Loading);

			try
			{
				await SceneManager.LoadSceneAsync(GameSceneName, LoadSceneMode.Single);

				// 50% chance of exception
				var simulateBadConnection = Random.Range(0, 2) == 1;
				var startLoadTime = Time.realtimeSinceStartup;

				while (startLoadTime + 5f > Time.realtimeSinceStartup)
				{
					if (simulateBadConnection && startLoadTime + 2f < Time.realtimeSinceStartup)
					{
						Debug.LogError($"Mock internet connection problem");
						CancellationTokenSource?.Cancel();
					}

					await UniTask.Yield(CancellationTokenSource.Token);
				}

				UiSystem.ShowScreen(ScreenType.Hud);
			}
			catch (OperationCanceledException)
			{
				LoadMainMenu();

				CancellationTokenSource = new CancellationTokenSource();

				// TODO: Here we can show some popup about loading problem
				Debug.LogError($"Loading canceled..");
			}
		}

		public void LoadMainMenu()
		{
			ActiveSession = null;
			SceneManager.LoadScene(MainMenuSceneName, LoadSceneMode.Single);
			UiSystem.ShowScreen(ScreenType.MainMenu);
		}

		public void Quit()
		{
			ActiveSession = null;
			UnityEngine.Application.Quit();
		}

		public void Dispose()
		{
			CancellationTokenSource?.Cancel();
			CancellationTokenSource?.Dispose();
			CancellationTokenSource = null;
		}
	}
}