using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject resumeButton;
    [SerializeField]
    private GameObject mainMenuButton;
    [SerializeField]
    private GameObject resourcesButton;
    [SerializeField]
    private GameObject resourcesPage;
    [SerializeField]
    private GameObject backButton;
    [SerializeField]
    private GameObject pauseButton;    
    [SerializeField]
    private GameObject pauseBackground;
    [SerializeField]
    private GameObject pauseMenuText;
    [SerializeField]
    private GameObject dialogue;
    [HideInInspector]
    public bool isgamePaused;

    private void Start()
    {
        isgamePaused = false;
        dialogue = GameObject.FindGameObjectWithTag("Text");
    }
    public void PressPauseButton()
    {
        IsPaused(true);
    }
    public void PressResumeButton()
    {
        IsPaused(false);
    }

    public void PressResourcesButton()
    {
        resourcesPage.SetActive(true);
        resumeButton.SetActive(false);
        resourcesButton.SetActive(false);
        mainMenuButton.SetActive(false);
        pauseMenuText.SetActive(false);
    }

    public void PressBackButton()
    {
        resourcesPage.SetActive(false);
        resumeButton.SetActive(true);
        resourcesButton.SetActive(true);
        mainMenuButton.SetActive(true);
        pauseMenuText.SetActive(true);
    }

    public void PressMainMenuButton()
    {
        IsPaused(false);
        SceneManager.LoadScene(0);
    }

    public void IsPaused(bool gamePaused)
    {
        if (gamePaused)
        {
            isgamePaused = true;
            Time.timeScale = 0;
            dialogue.SetActive(false);
            pauseButton.SetActive(false);
            resumeButton.SetActive(true);
            mainMenuButton.SetActive(true);
            pauseBackground.SetActive(true);
            pauseMenuText.SetActive(true);
            resourcesButton.SetActive(true);
        }
        else
        {
            isgamePaused = false;
            Time.timeScale = 1;
            dialogue.SetActive(true);
            pauseButton.SetActive(true);
            resumeButton.SetActive(false);
            mainMenuButton.SetActive(false);
            pauseBackground.SetActive(false);
            pauseMenuText.SetActive(false);
            resourcesButton.SetActive(false);
        }
    }
}
