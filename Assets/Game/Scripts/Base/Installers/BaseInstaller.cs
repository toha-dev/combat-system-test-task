using Game.Base.Application;
using Game.Base.Pause;
using Zenject;

namespace Game.Base.Installers
{
	public class BaseInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<IPauseService>().To<PauseService>().FromNew().AsSingle().NonLazy();
			Container.Bind<IApplication>().To<Application.Application>().FromNew().AsSingle().NonLazy();
		}
	}
}