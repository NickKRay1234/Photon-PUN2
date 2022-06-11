using UnityEngine;
using UnityEngine.UI;


public class Player : Character
{
    [SerializeField] private Text _healthText;

    public void TakeDamage(float damage)
    {
        Health -= damage;
        _healthText.text = "Health: " + Health.ToString();
        if (Health <= 0) GameOver.OnGameOver.Invoke();
    }
}
