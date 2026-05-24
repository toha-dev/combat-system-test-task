using Game.Base.UI;
using Game.UI.System;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI.Installers
{
	public class UiInstaller : MonoInstaller
	{
		[field: SerializeField]
		private SimpleUiSystem SimpleUiSystem { get; set; }

		public override void InstallBindings()
		{
			Container.Bind<IUiSystem>().FromInstance(SimpleUiSystem).AsSingle().NonLazy();
		}
	}
}