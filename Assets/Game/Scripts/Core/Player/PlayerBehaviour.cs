using System;
using System.Collections.Generic;
using Game.Core.Ability;
using Game.Core.Ability.Utils;
using Game.Core.Configs.Ability;
using Game.Core.Configs.Attack;
using Game.Core.Player.Attack;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game.Core.Player
{
	public class PlayerBehaviour : MonoBehaviour
	{
		[field: SerializeField]
		private InputActionReference BaseAttackInput { get; set; }

		[field: SerializeField]
		private InputActionReference SpecialAttackInput { get; set; }

		[Inject]
		private DiContainer Container { get; set; }

		public List<AbilityBase> Abilities { get; } = new();

		public AttackBehaviourBase BaseAttack { get; set; }
		public AttackBehaviourBase SpecialAttack { get; set; }

		public float Health { get; private set; }
		public bool IsAlive => Health > 0f;

		public event Action EventPlayerDied;
		public event Action EventHealthChanged;

		public void Initialize(List<BaseAbilityConfig> abilities, AttackConfig baseAttack, AttackConfig specialAttack)
		{
			abilities.ForEach(x => Abilities.Add(x.CreateAbility()));
			BaseAttack = AddAttackBehaviour(baseAttack, BaseAttackInput);
			SpecialAttack = AddAttackBehaviour(specialAttack, SpecialAttackInput);

			Health = 100f;
		}

		private AttackBehaviourBase AddAttackBehaviour(AttackConfig config, InputActionReference inputActionReference)
		{
			// Extendable system for player attack. Here we can create and add implementation for attack type.
			// Every attack type can have multiple configs, for example DistanceAttackConfig_LVL1, DistanceAttackConfig_LVL2..
			// These configs can contain different params, for example bigger attack range or different cooldown in seconds.
			AttackBehaviourBase attackBehaviour = config switch
			{
				MeleeAttackConfig => gameObject.AddComponent<MeleeAttackBehaviour>(),
				DistanceAttackConfig => gameObject.AddComponent<DistanceAttackAreaBehaviour>(),
				_ => throw new ArgumentOutOfRangeException($"There is no such type of attack implementation found! {nameof(config)}")
			};

			Container.Inject(attackBehaviour);
			attackBehaviour.Initialize(config, inputActionReference);
			return attackBehaviour;
		}

		public void Damage(float damage)
		{
			if (damage > 0)
			{
				Debug.Log($"Player damaged for {damage}");
				Health = Mathf.Max(0, Health - damage);

				EventHealthChanged?.Invoke();

				if (Health == 0f)
				{
					EventPlayerDied?.Invoke();
				}
			}
		}
	}
}