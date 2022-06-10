using UnityEngine;
using UnityEngine.UI;


public class Player : Character
{
    [SerializeField] private Text _healthText;

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(Damage);
        _healthText.text = "Health: " + Health.ToString();
        if (Health <= 0) GameOver.OnGameOver.Invoke();
    }
}
