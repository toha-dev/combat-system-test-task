using System;
using System.Collections.Generic;
using Game.Core.Configs.Ability;
using UnityEngine;
using Zenject;

namespace Game.Core.Enemy
{
	public class EnemySpawner : MonoBehaviour
	{
		[field: SerializeField]
		private List<BaseAbilityConfig> EnemyAbilities { get; set; }

		[Inject]
		private EnemyBehaviour.Pool EnemyPool { get; set; }

		private readonly List<EnemyBehaviour> _enemies = new();

		public event Action<EnemyBehaviour> EventEnemySpawned;

		public void Spawn()
		{
			var enemy = EnemyPool.Spawn(transform.position, EnemyAbilities);
			enemy.EventEnemyDied += OnEnemyDied;
			_enemies.Add(enemy);
			EventEnemySpawned?.Invoke(enemy);
		}

		private void OnDestroy()
		{
			foreach (var enemy in _enemies)
			{
				enemy.EventEnemyDied -= OnEnemyDied;
			}
		}

		private void OnEnemyDied(EnemyBehaviour enemyBehaviour)
		{
			enemyBehaviour.EventEnemyDied -= OnEnemyDied;
			EnemyPool.Despawn(enemyBehaviour);
			_enemies.Remove(enemyBehaviour);
		}
	}
}