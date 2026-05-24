using Game.Base.Application;
using Game.Core;

namespace Game.UI.Extensions
{
	public static class ApplicationExtension
	{
		public static GameController GetGameController(this IApplication application)
		{
			return (GameController)application.ActiveSession;
		}
	}
}