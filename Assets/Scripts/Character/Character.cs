using UnityEngine;


public abstract class Character : MonoBehaviour
{
    [SerializeField] protected float _damage = 25f;
    [SerializeField] protected float _health = 100f;
    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public float Health
    {
        get { return _health; }
        set { _health = value; }
    }
    
    public virtual void TakeDamage(float damage)
    {
        Health -= damage;
    }
}
