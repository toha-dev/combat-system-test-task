using System.Collections.Generic;
using Game.Core.Configs.Attack;
using Game.Core.Enemy;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Core.Player.Attack
{
	// Base attack for player. Can be extended in derived classes
	public abstract class AttackBehaviour<TAttackConfig> : AttackBehaviourBase where TAttackConfig : AttackConfig
	{
		protected TAttackConfig Config => (TAttackConfig)AttackConfigBase;

		public override bool IsOnCooldown => LastAttackTime + Config.CoolDownSeconds > Time.time;

		private float LastAttackTime { get; set; }

		public override void Initialize(AttackConfig config, InputActionReference inputActionReference)
		{
			base.Initialize(config, inputActionReference);
			InputActionReference.action.performed += OnAttackPerformed;
			InputActionReference.action.Enable();
			LastAttackTime = float.MinValue;
		}

		private void OnDestroy()
		{
			InputActionReference.action.performed -= OnAttackPerformed;
			InputActionReference.action.Disable();
		}

		private void OnAttackPerformed(InputAction.CallbackContext _)
		{
			if (CanAttackNow())
			{
				Attack(FindTargets());
				LastAttackTime = Time.time;
			}
		}

		protected virtual bool CanAttackNow()
		{
			return PlayerBehaviour.IsAlive && !IsOnCooldown;
		}

		protected abstract List<EnemyBehaviour> FindTargets();

		protected abstract void Attack(List<EnemyBehaviour> targets);
	}
}