using System;
using Game.Core.Configs.Ability;

namespace Game.Core.Ability.Utils
{
	public static class AbilityExtensions
	{
		public static AbilityBase CreateAbility(this BaseAbilityConfig abilityConfig)
		{
			// Extendable ability system for Health/Damage. Every ability type can modify damage TO enemy or damage FROM enemy.
			// The same as for attack, this system can have multiple configs, for example CriticalDamageAbilityConfig_LVL1, CriticalDamageAbilityConfig_LVL2..
			// These ability used in CombatSystem to modify damage.
			AbilityBase ability = abilityConfig switch
			{
				CriticalDamageAbilityConfig => new CriticalDamageAbility(),
				EvadeDamageAbilityConfig => new EvadeDamageAbility(),
				ProtectionAbilityConfig => new ProtectionAbility(),
				_ => throw new ArgumentOutOfRangeException($"There is no such type of ability implementation found! {nameof(abilityConfig)}")
			};

			ability.Initialize(abilityConfig);
			return ability;
		}
	}
}