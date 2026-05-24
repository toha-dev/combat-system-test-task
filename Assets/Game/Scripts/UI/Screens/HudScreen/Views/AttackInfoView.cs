using Game.Core.Player.Attack;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Screens.HudScreen.Views
{
	public class AttackInfoView : MonoBehaviour
	{
		[field: SerializeField]
		private Image AttackState { get; set; }

		private AttackBehaviourBase AttackBehaviour { get; set; }

		public void Initialize(AttackBehaviourBase attackBehaviour)
		{
			AttackBehaviour = attackBehaviour;
		}

		private void Update()
		{
			AttackState.color = AttackBehaviour.IsOnCooldown ? Color.red : Color.white;
		}
	}
}