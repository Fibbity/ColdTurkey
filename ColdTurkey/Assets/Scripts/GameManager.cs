using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private AudioSource audioSource;
    private AudioClip menuMusic;
    [SerializeField]
    private AudioClip levelOneMusic;
    [SerializeField]
    private AudioClip levelTwoMusic;
    [SerializeField]
    private AudioClip levelThreeMusic;
    public static int levelCount;
    public static int previouslevelCount;

    private StateType currentStateType;
    public enum StateType
    {
        MENU,
        PLAYING,
        PAUSED,
        WIN,
        LOSE
    }    
    public static GameMode currentGameMode;
    public enum GameMode
    {
        STORY,
        CHAPTER,
        HARDCORE
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(this);
            GetLevel();
        }
        instance = this;

    }
    private void Start()
    {
        StartCoroutine(GameRunning());
        audioSource.Play();
    }

    private void GetLevel()
    {
        audioSource.Stop();

        previouslevelCount = levelCount;
        levelCount = SceneManager.GetActiveScene().buildIndex;

        Debug.Log("Previous Level Index: " + previouslevelCount);
        Debug.Log("Current Level Index: " + levelCount);

        switch (levelCount)
        {
            case 1:
                ChangeMusic(levelOneMusic);
                break;
            case 2:
                ChangeMusic(levelTwoMusic);
                break;
            case 3:
                ChangeMusic(levelThreeMusic);
                break;

            default: 
                ChangeMusic(levelThreeMusic);
                break;
        }
        Debug.Log(currentGameMode);
    }

    void ChangeMusic(AudioClip music)
    {
        audioSource.clip = music;
        audioSource.Play();
    }

    private IEnumerator GameRunning()
    {
        while (true)
        {
            if (PlayerMovement.currentHealth < 4)                     
            {
                currentStateType = StateType.PLAYING;
                StartCoroutine(GamePlaying());
            }
            else
            {
                currentStateType = StateType.LOSE;
                GameLost();
            }

            if (SceneManager.GetActiveScene().buildIndex != levelCount)
            {
                GetLevel();
            }
            yield return new WaitForSeconds(.1f);
        }
    }
    private IEnumerator GamePlaying()
    {
        while (currentStateType == StateType.PLAYING)
        {
            if (WinTrigger.levelCompleted == true)
            {
                Debug.Log("Game Won");
                currentStateType = StateType.WIN;
                GameWon();
            }
            yield return new WaitForSeconds(.5f);
        }
    }
    private void GameLost()
    {
        StopCoroutine(GamePlaying());
        PlayerMovement.currentHealth = 0;
        if (levelCount == 9)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(5);
        }
        GetLevel();
    }

    private void GameWon()
    {
        StopCoroutine(GamePlaying());
        PlayerMovement.currentHealth = 0;
        WinTrigger.levelCompleted = false;
        if (currentGameMode == GameMode.STORY)
        {
            if (levelCount == 3)
            {
                SceneManager.LoadScene(8);
            }
        }
        if (levelCount == 7)
        {
            SceneManager.LoadScene(0);
        }
        else if (levelCount == 9)
        {
            SceneManager.LoadScene(0);
        }        
        else if (levelCount == 6)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(4);
        }
    }

}
