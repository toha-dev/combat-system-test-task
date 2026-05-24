using UnityEngine;

namespace Game.Core.Configs.Ability
{
	[CreateAssetMenu(fileName = "EvadeDamageAbilityConfig", menuName = "Configs/Ability/EvadeDamageAbilityConfig")]
	public class EvadeDamageAbilityConfig : BaseAbilityConfig
	{
		[field: SerializeField]
		[field: Range(0f, 1f)]
		public float ProbabilityPercent { get; private set; }
	}
}