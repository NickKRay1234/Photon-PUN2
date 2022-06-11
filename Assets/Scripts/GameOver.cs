using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Text _roundSurvived;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private int _round;

    public static UnityEvent OnGameOver;

    private void Start()
    {
        if(OnGameOver == null) OnGameOver = new UnityEvent(); 
        OnGameOver.AddListener(EndGame);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    
    private void EndGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        _endScreen.SetActive(true);
        _roundSurvived.text = _round.ToString();
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
