using UnityEngine;

namespace Game.Base.Pause
{
	public class PauseService : IPauseService
	{
		public bool IsGamePaused { get; private set; } = false;
		private float TimeScaleBeforePause { get; set; }

		public void PauseGame()
		{
			IsGamePaused = true;
			TimeScaleBeforePause = Time.timeScale;
			Time.timeScale = 0f;
		}

		public void UnpauseGame()
		{
			IsGamePaused = false;
			Time.timeScale = TimeScaleBeforePause;
		}
	}
}