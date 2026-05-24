using Game.Core.Combat;
using Game.Core.Configs.Attack;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game.Core.Player.Attack
{
	public class AttackBehaviourBase : MonoBehaviour
	{
		[Inject]
		protected CombatSystem CombatSystem { get; private set; }

		[Inject]
		protected GameController GameController { get; private set; }

		[Inject]
		protected PlayerBehaviour PlayerBehaviour { get; private set; }

		protected InputActionReference InputActionReference { get; private set; }
		protected AttackConfig AttackConfigBase { get; private set; }

		public virtual bool IsOnCooldown { get; protected set; }

		public virtual void Initialize(AttackConfig config, InputActionReference inputActionReference)
		{
			AttackConfigBase = config;
			InputActionReference = inputActionReference;
		}
	}
}