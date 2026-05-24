using System.Collections.Generic;
using System.Linq;
using Game.Base.Application;
using Game.Base.Session;
using Game.Base.UI;
using Game.Core.Configs.Ability;
using Game.Core.Configs.Attack;
using Game.Core.Enemy;
using Game.Core.Level;
using Game.Core.Player;
using UnityEngine;
using Zenject;

namespace Game.Core
{
	public class GameController : MonoBehaviour, IGameSession
	{
		[field: SerializeField]
		private LevelData LevelData { get; set; }

		// Hardcoded player attacks. In future we can add screen where user can select attack types for main character
		// Base attack is Melee weapon, Special attack is Distance weapon.
		[field: SerializeField]
		private List<AttackConfig> HardcodedPlayerAttacks { get; set; }

		// Hardcoded player abilities. In future we can add items for pickup, and every item will add some ability to main character.
		// 3 abilities here: 20% of critical damage (x2 damage), 10% of damage evasion (0 damage to player from enemy), 10% protection from all damage.
		[field: SerializeField]
		private List<BaseAbilityConfig> HardcodedPlayerAbilities { get; set; }

		[Inject]
		private IApplication Application { get; set; }

		[Inject]
		public PlayerBehaviour PlayerBehaviour { get; private set; }

		[Inject]
		private IUiSystem UiSystem { get; set; }

		public HashSet<EnemyBehaviour> EnemyBehaviours { get; } = new();

		public int KilledEnemies { get; private set; }

		private bool BattleStarted { get; set; }

		private void Awake()
		{
			Application.RegisterSession(this);
			LevelData.BattleAreaBehaviour.EventPlayerTriggerEntered += OnPlayerEnteredBattleArea;
			PlayerBehaviour.EventPlayerDied += OnPlayerDied;

			foreach (var spawner in LevelData.EnemySpawners)
			{
				spawner.EventEnemySpawned += OnEnemySpawned;
			}

			// It can be different attacks and abilities, but now these parameters hardcoded
			PlayerBehaviour.Initialize(HardcodedPlayerAbilities, HardcodedPlayerAttacks[0], HardcodedPlayerAttacks[1]);
		}

		private void OnDestroy()
		{
			LevelData.BattleAreaBehaviour.EventPlayerTriggerEntered -= OnPlayerEnteredBattleArea;
			PlayerBehaviour.EventPlayerDied -= OnPlayerDied;

			foreach (var spawner in LevelData.EnemySpawners)
			{
				spawner.EventEnemySpawned -= OnEnemySpawned;
			}

			EnemyBehaviours.Clear();
		}

		private void OnPlayerEnteredBattleArea()
		{
			if (BattleStarted)
			{
				return;
			}

			LevelData.EnemySpawners.ForEach(x => x.Spawn());
			BattleStarted = true;
		}

		private void OnEnemySpawned(EnemyBehaviour enemyBehaviour)
		{
			EnemyBehaviours.Add(enemyBehaviour);
			enemyBehaviour.EventEnemyDied += OnEnemyDied;
		}

		private void OnEnemyDied(EnemyBehaviour enemyBehaviour)
		{
			enemyBehaviour.EventEnemyDied -= OnEnemyDied;
			EnemyBehaviours.Remove(enemyBehaviour);
			KilledEnemies++;

			if (!EnemyBehaviours.Any())
			{
				OnAllEnemiesDied();
			}
		}

		private void OnPlayerDied()
		{
			UiSystem.ShowScreen(ScreenType.Defeat);
		}

		private void OnAllEnemiesDied()
		{
			UiSystem.ShowScreen(ScreenType.Victory);
		}
	}
}