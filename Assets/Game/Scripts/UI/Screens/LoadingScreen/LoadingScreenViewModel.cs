using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.UI.Screens.LoadingScreen
{
	public class LoadingScreenViewModel : ScreenViewModel
	{
		public float LoadingProgress { get; private set; }

		public override void Initialize()
		{
			LoadingProgress = 0f;

			FakeLoadingProgressFor5Seconds().Forget();

			async UniTask FakeLoadingProgressFor5Seconds()
			{
				var startTime = Time.realtimeSinceStartup;

				while (startTime + 5f > Time.realtimeSinceStartup)
				{
					LoadingProgress = (Time.realtimeSinceStartup - startTime) / 5f;
					await UniTask.Yield();
				}

				LoadingProgress = 1f;
			}
		}
	}
}