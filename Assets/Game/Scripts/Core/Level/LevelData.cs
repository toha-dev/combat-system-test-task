using System.Collections.Generic;
using System.Linq;
using Game.Core.Enemy;
using UnityEngine;

namespace Game.Core.Level
{
	public class LevelData : MonoBehaviour
	{
		[field: SerializeField]
		public List<EnemySpawner> EnemySpawners { get; private set; }

		[field: SerializeField]
		public BattleAreaBehaviour BattleAreaBehaviour { get; private set; }

		[ContextMenu("Collect")]
		private void CollectData()
		{
			EnemySpawners = GetComponentsInChildren<EnemySpawner>().ToList();
			BattleAreaBehaviour = GetComponentInChildren<BattleAreaBehaviour>();
		}
	}
}