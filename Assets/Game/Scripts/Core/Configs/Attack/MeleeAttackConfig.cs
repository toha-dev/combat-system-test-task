using UnityEngine;

namespace Game.Core.Configs.Attack
{
	[CreateAssetMenu(fileName = "MeleeAttackConfig", menuName = "Configs/Attack/MeleeAttackConfig")]
	public class MeleeAttackConfig : AttackConfig
	{
		[field: SerializeField]
		public int MaxTargets { get; private set; }

		[field: SerializeField]
		public float AttackRange { get; private set; }
	}
}