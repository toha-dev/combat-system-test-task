using Game.Core.Configs.Ability;

namespace Game.Core.Ability
{
	public abstract class AbilityBase
	{
		public BaseAbilityConfig BaseConfig { get; private set; }

		public void Initialize(BaseAbilityConfig config) => BaseConfig = config;

		public virtual float ApplyToMakeDamage(float makeDamage) => makeDamage;
		public virtual float ApplyToTakeDamage(float takeDamage) => takeDamage;
	}
}