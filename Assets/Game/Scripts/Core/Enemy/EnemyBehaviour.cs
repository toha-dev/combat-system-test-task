using System;
using System.Collections.Generic;
using Game.Core.Ability;
using Game.Core.Ability.Utils;
using Game.Core.Configs.Ability;
using UnityEngine;
using Zenject;

namespace Game.Core.Enemy
{
	public class EnemyBehaviour : MonoBehaviour
	{
		public List<AbilityBase> Abilities { get; } = new();

		public float Health { get; private set; }

		public event Action<EnemyBehaviour> EventEnemyDied;
		public event Action EventHealthChanged;

		private void Initialize(List<BaseAbilityConfig> abilities)
		{
			abilities.ForEach(x => Abilities.Add(x.CreateAbility()));

			Health = 100f;
			EventHealthChanged?.Invoke();
		}

		public void Damage(float damage)
		{
			if (damage > 0)
			{
				Debug.Log($"Enemy damaged for {damage}");
				Health = Mathf.Max(0, Health - damage);

				EventHealthChanged?.Invoke();

				if (Health == 0f)
				{
					EventEnemyDied?.Invoke(this);
				}
			}
		}

		public class Pool : MonoMemoryPool<Vector3, List<BaseAbilityConfig>, EnemyBehaviour>
		{
			protected override void Reinitialize(Vector3 spawnPosition, List<BaseAbilityConfig> abilities, EnemyBehaviour enemyBehaviour)
			{
				enemyBehaviour.transform.position = spawnPosition;
				enemyBehaviour.Initialize(abilities);
			}
		}
	}
}