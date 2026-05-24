using Cysharp.Threading.Tasks;
using Game.Base.Session;

namespace Game.Base.Application
{
	public interface IApplication
	{
		public UniTask StartGame();
		public void LoadMainMenu();
		public void Quit();

		public IGameSession ActiveSession { get; }

		public void RegisterSession(IGameSession gameSession);
	}
}