using System.Collections.Generic;
using Game.Core.Ability;
using Game.Core.Enemy;
using Game.Core.Player;

namespace Game.Core.Combat
{
	public class CombatSystem
	{
		private enum DamageType
		{
			To = 0,
			From = 1,
		}

		public void DealDamage(EnemyBehaviour from, PlayerBehaviour to, float damage)
		{
			var damageToPlayer = CalculateDamageAfterAbilities(from.Abilities, damage, DamageType.To);
			damageToPlayer = CalculateDamageAfterAbilities(to.Abilities, damageToPlayer, DamageType.From);

			if (damageToPlayer > 0)
			{
				to.Damage(damageToPlayer);
			}
		}

		public void DealDamage(PlayerBehaviour from, List<EnemyBehaviour> to, float damage)
		{
			foreach (var enemy in to)
			{
				var damageToEnemy = CalculateDamageAfterAbilities(from.Abilities, damage, DamageType.To);
				damageToEnemy = CalculateDamageAfterAbilities(enemy.Abilities, damageToEnemy, DamageType.From);

				if (damageToEnemy > 0)
				{
					enemy.Damage(damageToEnemy);
				}
			}
		}

		private float CalculateDamageAfterAbilities(List<AbilityBase> abilities, float initialDamage, DamageType damageType)
		{
			var result = initialDamage;

			foreach (var ability in abilities)
			{
				var damageAfterAbility = damageType is DamageType.To
					? ability.ApplyToMakeDamage(initialDamage)
					: ability.ApplyToTakeDamage(initialDamage);
				var difference = initialDamage - damageAfterAbility;

				result -= difference;
			}

			return result;
		}
	}
}