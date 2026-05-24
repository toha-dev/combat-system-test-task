using System.Collections.Generic;
using Game.Core.Configs.Attack;
using Game.Core.Enemy;
using UnityEngine;

namespace Game.Core.Player.Attack
{
	public class DistanceAttackAreaBehaviour : AttackBehaviour<DistanceAttackConfig>
	{
		protected override List<EnemyBehaviour> FindTargets()
		{
			var attackCenter = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
			var sqrRange = Mathf.Pow(Config.AttackRange, 2);
			var targets = new List<EnemyBehaviour>();

			foreach (var enemy in GameController.EnemyBehaviours)
			{
				if (Vector2.SqrMagnitude(enemy.transform.position - attackCenter) <= sqrRange)
				{
					targets.Add(enemy);
				}
			}

			return targets;
		}

		protected override void Attack(List<EnemyBehaviour> targets)
		{
			Debug.Log($"Player attack {nameof(DistanceAttackAreaBehaviour)}");
			CombatSystem.DealDamage(PlayerBehaviour, targets, Config.Damage);
		}
	}
}