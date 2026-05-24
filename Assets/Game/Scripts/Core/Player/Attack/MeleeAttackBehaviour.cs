using System.Collections.Generic;
using Game.Core.Configs.Attack;
using Game.Core.Enemy;
using UnityEngine;

namespace Game.Core.Player.Attack
{
	public class MeleeAttackBehaviour : AttackBehaviour<MeleeAttackConfig>
	{
		protected override List<EnemyBehaviour> FindTargets()
		{
			var playerPosition = PlayerBehaviour.transform.position;
			var sqrRange = Mathf.Pow(Config.AttackRange, 2);
			var targets = new List<EnemyBehaviour>(Config.MaxTargets);

			foreach (var enemy in GameController.EnemyBehaviours)
			{
				if (Vector2.SqrMagnitude(enemy.transform.position - playerPosition) <= sqrRange)
				{
					targets.Add(enemy);
				}

				if (targets.Count >= Config.MaxTargets)
				{
					break;
				}
			}

			return targets;
		}

		protected override void Attack(List<EnemyBehaviour> targets)
		{
			Debug.Log($"Player attack {nameof(MeleeAttackBehaviour)}");
			CombatSystem.DealDamage(PlayerBehaviour, targets, Config.Damage);
		}
	}
}