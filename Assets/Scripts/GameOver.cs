using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Text _roundSurvived;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private int round = 0;

    public static UnityEvent OnGameOver;

    private void Start()
    {
        if(OnGameOver == null) OnGameOver = new UnityEvent();
        OnGameOver.AddListener(EndGame);
    }
    
    private void EndGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        _endScreen.SetActive(true);
        _roundSurvived.text = round.ToString();
    }
}
