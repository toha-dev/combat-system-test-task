using System;
using Game.Core.Player;
using UnityEngine;

namespace Game.Core.Level
{
	public class BattleAreaBehaviour : MonoBehaviour
	{
		private bool TriggerUsed { get; set; }

		public event Action EventPlayerTriggerEntered;

		private void OnTriggerEnter2D(Collider2D anotherCollider)
		{
			if (TriggerUsed)
			{
				return;
			}

			if (anotherCollider.gameObject.TryGetComponent<PlayerBehaviour>(out _))
			{
				EventPlayerTriggerEntered?.Invoke();
				TriggerUsed = true;
			}
		}
	}
}