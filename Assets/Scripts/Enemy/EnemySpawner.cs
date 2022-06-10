using UnityEngine;
using UnityEngine.UI;

    public class EnemySpawner : MonoBehaviour
    {

        public int AliveEnemiesCount
        {
            get => _aliveEnemiesCount;
            set => _aliveEnemiesCount = value;
        }
        
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private int _aliveEnemiesCount = 0;
        [SerializeField] private int round = 0;
        [SerializeField] private Text _roundNumber;

        private void Update()
        {
            if (_aliveEnemiesCount == 0)
            {
                round++;
                StartWave(round);
                _roundNumber.text = "Round: " + round.ToString();
            }
        }

        private void StartWave(int round)
        {
            for (int x = 0; x < round; x++)
            {
                Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
                Instantiate(_enemyPrefab, spawnPoint.position, Quaternion.identity);
                _aliveEnemiesCount++;
            }
        }
    } 

