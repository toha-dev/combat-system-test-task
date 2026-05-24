using UnityEngine;
using Zenject;

namespace Game.Base.Application
{
	public class Launcher : MonoBehaviour
	{
		[Inject]
		private void Construct(IApplication application)
		{
			application.LoadMainMenu();
		}
	}
}
