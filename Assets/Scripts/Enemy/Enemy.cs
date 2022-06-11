using UnityEngine;
using UnityEngine.AI;

    public class Enemy : Character
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _player;

        private string RunStateAnimationName = "isRunning";
        private NavMeshAgent _navMeshAgent;
        [SerializeField] private Player _playerHealth;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _playerHealth = _player.GetComponent<Player>();
        }

        private void Update()
        {
            _navMeshAgent.destination = _player.transform.position;
            if (_navMeshAgent.velocity.magnitude > 1)
                _animator.SetBool(RunStateAnimationName, true);
            else 
                _animator.SetBool(RunStateAnimationName, false);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == _player)
            {
                _playerHealth.TakeDamage(_damage);
            }
        }

        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);
            print(Health);
            if (Health <= 0)
            {
                Destroy(gameObject);
                EnemySpawner.ReduceEnemyCounter.Invoke();
            }
        }
    }

