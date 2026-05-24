using UnityEngine;

namespace Game.Core.Configs.Ability
{
	[CreateAssetMenu(fileName = "ProtectionAbilityConfig", menuName = "Configs/Ability/ProtectionAbilityConfig")]
	public class ProtectionAbilityConfig : BaseAbilityConfig
	{
		[field: SerializeField]
		[field: Range(0f, 1f)]
		public float ProtectionPercent { get; private set; }
	}
}