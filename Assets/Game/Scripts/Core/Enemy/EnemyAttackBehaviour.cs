using Game.Core.Combat;
using Game.Core.Player;
using UnityEngine;
using Zenject;

namespace Game.Core.Enemy
{
	// Simple melee spam attack for enemies. Not extendable system
	public class EnemyAttackBehaviour : MonoBehaviour
	{
		[field: SerializeField]
		private EnemyBehaviour EnemyBehaviour { get; set; }

		[field: SerializeField]
		private float CoolDownSeconds { get; set; }

		[field: SerializeField]
		private float Damage { get; set; }

		[field: SerializeField]
		private float Range { get; set; }

		[Inject]
		private CombatSystem CombatSystem { get; set; }

		[Inject]
		private PlayerBehaviour PlayerBehaviour { get; set; }

		private float SqrRange { get; set; }
		private float LastAttackTime { get; set; }

		private void Awake()
		{
			SqrRange = Mathf.Pow(Range, 2);
		}

		private void Update()
		{
			if (LastAttackTime + CoolDownSeconds >= Time.time)
			{
				return;
			}

			var sqrMagnitude = Vector2.SqrMagnitude(PlayerBehaviour.transform.position - transform.position);

			if (sqrMagnitude < SqrRange)
			{
				Attack();
				LastAttackTime = Time.time;
			}
		}

		private void Attack()
		{
			CombatSystem.DealDamage(EnemyBehaviour, PlayerBehaviour, Damage);
		}
	}
}