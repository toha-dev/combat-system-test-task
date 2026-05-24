namespace Game.UI.Screens
{
	public abstract class ScreenView<TViewModel> : BaseScreenView where TViewModel : ScreenViewModel
	{
		protected TViewModel ViewModel { get; private set; }

		internal override void Initialize(ScreenViewModel viewModel)
		{
			BaseViewModel = ViewModel = (TViewModel)viewModel;
		}
	}
}