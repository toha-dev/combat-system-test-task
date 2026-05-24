using Game.Core.Combat;
using Game.Core.Enemy;
using Game.Core.Player;
using UnityEngine;
using Zenject;

namespace Game.Core.Installers
{
	public class GameInstaller : MonoInstaller
	{
		[field: SerializeField]
		private EnemyBehaviour EnemyPrefab { get; set; }

		[field: SerializeField]
		private PlayerBehaviour PlayerBehaviour { get; set; }

		[field: SerializeField]
		private GameController GameController { get; set; }

		public override void InstallBindings()
		{
			Container.Bind<CombatSystem>().FromNew().AsSingle().NonLazy();
			Container.BindInterfacesAndSelfTo<PlayerBehaviour>().FromInstance(PlayerBehaviour).AsSingle().NonLazy();
			Container.BindInterfacesAndSelfTo<GameController>().FromInstance(GameController).AsSingle().NonLazy();

			Container.BindMemoryPool<EnemyBehaviour, EnemyBehaviour.Pool>()
				.WithInitialSize(10)
				.FromComponentInNewPrefab(EnemyPrefab)
				.UnderTransformGroup("Enemies");
		}
	}
}