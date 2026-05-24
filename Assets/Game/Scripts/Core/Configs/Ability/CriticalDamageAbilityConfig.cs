using UnityEngine;

namespace Game.Core.Configs.Ability
{
	[CreateAssetMenu(fileName = "CriticalDamageAbilityConfig", menuName = "Configs/Ability/CriticalDamageAbilityConfig")]
	public class CriticalDamageAbilityConfig : BaseAbilityConfig
	{
		[field: SerializeField]
		[field: Range(1f, 2f)]
		public float CriticalDamageMultiplier { get; private set; }

		[field: SerializeField]
		[field: Range(0f, 1f)]
		public float ProbabilityPercent { get; private set; }
	}
}