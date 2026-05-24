using Game.Core.Enemy;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Screens.WorldCanvas
{
	public class EnemyHealthBarView : MonoBehaviour
	{
		[field: SerializeField]
		private EnemyBehaviour EnemyBehaviour { get; set; }

		[field: SerializeField]
		private Slider HealthBar { get; set; }

		private void OnEnable()
		{
			EnemyBehaviour.EventHealthChanged += OnHealthChanged;
			OnHealthChanged();
		}

		private void OnDisable()
		{
			EnemyBehaviour.EventHealthChanged -= OnHealthChanged;
		}

		private void OnHealthChanged()
		{
			HealthBar.value = EnemyBehaviour.Health / 100f;
		}
	}
}