using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static SceneManager singleton;

    enum gameScenes
    {
        MainMenu,
        Gameplay,
        GameOver
    }

    public float time;
    public float score;
    public bool gameWon;
    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(singleton.gameObject);
        }
        else if (singleton != gameObject)
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        GameManager.OnGameEnd += LoadGameOver;
        ToMenu.onClick += LoadMainMenu;
        ToGameplay.onClick += LoadGameplay;
    }
    private void OnDisable()
    {
        GameManager.OnGameEnd -= LoadGameOver;
        ToMenu.onClick -= LoadMainMenu;
        ToGameplay.onClick += LoadGameplay;
    }
    void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)gameScenes.MainMenu);
    }
    void LoadGameplay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)gameScenes.Gameplay);
    }
    void LoadGameOver(bool gameResult, float achievedScore, float timeSpent)
    {
        gameWon = gameResult;
        score = achievedScore;
        time = timeSpent;
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)gameScenes.GameOver);
    }
}
