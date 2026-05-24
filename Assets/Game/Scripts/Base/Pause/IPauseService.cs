namespace Game.Base.Pause
{
	public interface IPauseService
	{
		public bool IsGamePaused { get; }

		public void PauseGame();
		public void UnpauseGame();
	}
}