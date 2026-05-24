using UnityEngine;

namespace Game.Core.Configs.Attack
{
	[CreateAssetMenu(fileName = "DistanceAttackConfig", menuName = "Configs/Attack/DistanceAttackConfig")]
	public class DistanceAttackConfig : AttackConfig
	{
		[field: SerializeField]
		public float AttackRange { get; private set; }
	}
}