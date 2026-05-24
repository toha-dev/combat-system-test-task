using Game.Core.Player;
using UnityEngine;
using Zenject;

namespace Game.Core.Enemy
{
	public class EnemyController : MonoBehaviour
	{
		[field: SerializeField]
		private Rigidbody2D Rigidbody2D { get; set; }

		[field: SerializeField]
		private float Speed { get; set; }

		[field: SerializeField]
		private float TargetSqrDistanceToPlayer { get; set; }

		[Inject]
		private PlayerBehaviour PlayerBehaviour { get; set; }

		private void FixedUpdate()
		{
			var direction = (Vector2)PlayerBehaviour.transform.position - Rigidbody2D.position;

			if (Vector2.SqrMagnitude(direction) > TargetSqrDistanceToPlayer)
			{
				direction.Normalize();
				Rigidbody2D.MovePosition(Rigidbody2D.position + direction * (Speed * Time.fixedDeltaTime));
				Rigidbody2D.velocity = Vector3.zero;
			}
		}
	}
}