using Game.Core.Configs.Ability;

namespace Game.Core.Ability
{
	public class ProtectionAbility : AbilityBase
	{
		private ProtectionAbilityConfig Config => (ProtectionAbilityConfig)BaseConfig;

		public override float ApplyToTakeDamage(float takeDamage)
		{
			return takeDamage * (1f - Config.ProtectionPercent);
		}
	}
}