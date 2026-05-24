using UnityEngine;

namespace Game.Core.Configs.Ability
{
	public abstract class BaseAbilityConfig : ScriptableObject
	{
		[field: SerializeField]
		public string Name { get; private set; }

		[field: SerializeField]
		public string Description { get; private set; }
	}
}