using Game.Core.Configs.Ability;
using UnityEngine;

namespace Game.Core.Ability
{
	public class CriticalDamageAbility : AbilityBase
	{
		private CriticalDamageAbilityConfig Config => (CriticalDamageAbilityConfig)BaseConfig;

		public override float ApplyToMakeDamage(float makeDamage)
		{
			var randomNumber = Random.Range(0f, 1f);
			var multiplier = randomNumber < Config.ProbabilityPercent ? Config.CriticalDamageMultiplier : 1f;
			return makeDamage * multiplier;
		}
	}
}