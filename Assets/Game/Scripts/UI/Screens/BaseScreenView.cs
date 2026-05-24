using UnityEngine;

namespace Game.UI.Screens
{
	public abstract class BaseScreenView : MonoBehaviour
	{
		internal ScreenViewModel BaseViewModel { get; set; }

		public abstract void Show();
		public abstract void Hide();

		internal abstract void Initialize(ScreenViewModel viewModel);
	}
}