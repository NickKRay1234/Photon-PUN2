using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _mainCamera;
    [SerializeField] private float _range = 100f;
    [SerializeField] private float _damage = 25f;
    [SerializeField] private Animator _animator;
    private string ShootStateAnimationName = "isShooting";
    private Enemy Enemy;

    private void Start()
    {
        Enemy = GetComponent<Enemy>();
    }
    
    private void Update()
    {
        if (_animator.GetBool(ShootStateAnimationName)) 
            _animator.SetBool(ShootStateAnimationName, false);
        if (Input.GetMouseButtonDown(0)) Shoot();
    }

    private void Shoot()
    {
        _animator.SetBool(ShootStateAnimationName, true);
        if(Physics.Raycast(_mainCamera.position, transform.forward, out RaycastHit hit, _range))
        {
            Enemy = hit.transform.GetComponent<Enemy>();
            if (Enemy != null) 
                Enemy.TakeDamage(_damage);
        }
    }
}
