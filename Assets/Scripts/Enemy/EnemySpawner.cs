using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

    public class EnemySpawner : MonoBehaviour
    {
        public static UnityEvent ReduceEnemyCounter;

        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private int _aliveEnemy;
        [SerializeField] private int _roundNumber;
        [SerializeField] private Text _roundNumberText;

        private void ReduceCounterOfLivingOpponents() { _aliveEnemy--; }


        private void Start()
        {
            if (ReduceEnemyCounter == null) 
                ReduceEnemyCounter = new UnityEvent();
            ReduceEnemyCounter.AddListener(ReduceCounterOfLivingOpponents);
        }
        
        private void Update()
        {
            if (_aliveEnemy == 0)
            {
                StartWave(++_roundNumber);
                _roundNumberText.text = "Round: " + _roundNumber.ToString();
            }
        }

        private void StartWave(int round)
        {
            for (int x = 0; x < round; x++)
            {
                Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
                Instantiate(_enemyPrefab, spawnPoint.position, Quaternion.identity);
                _aliveEnemy++;
            }
        }
    } 

