using UnityEngine;

namespace Game.Core.Configs.Attack
{
	public abstract class AttackConfig : ScriptableObject
	{
		[field: SerializeField]
		public float CoolDownSeconds { get; private set; }

		[field: SerializeField]
		public float Damage { get; private set; }
	}
}