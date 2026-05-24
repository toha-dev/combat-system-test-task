using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Screens.LoadingScreen
{
	public class LoadingScreenView : ScreenView<LoadingScreenViewModel>
	{
		[field: SerializeField]
		private Slider LoadingProgress { get; set; }

		public override void Show()
		{
		}

		public override void Hide()
		{
		}

		private void LateUpdate()
		{
			LoadingProgress.value = ViewModel.LoadingProgress;
		}
	}
}