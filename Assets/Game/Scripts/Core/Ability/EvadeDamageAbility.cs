using Game.Core.Configs.Ability;
using UnityEngine;

namespace Game.Core.Ability
{
	public class EvadeDamageAbility : AbilityBase
	{
		private EvadeDamageAbilityConfig Config => (EvadeDamageAbilityConfig)BaseConfig;

		public override float ApplyToTakeDamage(float takeDamage)
		{
			var randomNumber = Random.Range(0f, 1f);
			var multiplier = randomNumber < Config.ProbabilityPercent ? 0f : 1f;
			return takeDamage * multiplier;
		}
	}
}