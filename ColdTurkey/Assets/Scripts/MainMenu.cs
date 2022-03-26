using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject startGameButton;
    [SerializeField]
    private GameObject tutorialGameButton;
    [SerializeField]
    private GameObject creditsGameButton;
    [SerializeField]
    private GameObject resourcesGameButton;
    [SerializeField]
    private GameObject resources;
    [SerializeField]
    private GameObject quitGameButton;
    [SerializeField]
    private GameObject title;
    [SerializeField]
    private GameObject backToMainButton;

    [SerializeField]
    private GameObject modeTitle;
    [SerializeField]
    private GameObject storyButton;
    [SerializeField]
    private GameObject chapterButton;
    [SerializeField]
    private GameObject sonicButton;

    [SerializeField]
    private GameObject levelOneButton;
    [SerializeField]
    private GameObject levelTwoButton;
    [SerializeField]
    private GameObject levelThreeButton;
    [SerializeField]
    private GameObject backToStartButton;
    public void PressStartButton()
    {
        startGameButton.SetActive(false);
        tutorialGameButton.SetActive(false);
        creditsGameButton.SetActive(false);
        resourcesGameButton.SetActive(false);
        quitGameButton.SetActive(false);
        title.SetActive(false);

        modeTitle.SetActive(true);
        backToMainButton.SetActive(true);
        storyButton.SetActive(true);
        chapterButton.SetActive(true);
        sonicButton.SetActive(true);
    }

    public void StoryMode()
    {
        GameManager.currentGameMode = GameManager.GameMode.STORY;
        SceneManager.LoadScene(1);
    }

    #region ChapterMode
    public void ChapterMode()
    {
        modeTitle.SetActive(false);
        backToMainButton.SetActive(false);
        storyButton.SetActive(false);
        chapterButton.SetActive(false);
        sonicButton.SetActive(false);

        levelOneButton.SetActive(true);
        levelTwoButton.SetActive(true);
        levelThreeButton.SetActive(true);
        backToStartButton.SetActive(true);
    }
    public void PressLevelOne()
    {
        GameManager.currentGameMode = GameManager.GameMode.CHAPTER;
        SceneManager.LoadScene(1);
    }
    public void PressLevelTwo()
    {
        GameManager.currentGameMode = GameManager.GameMode.CHAPTER;
        SceneManager.LoadScene(2);
    }
    public void PressLevelThree()
    {
        GameManager.currentGameMode = GameManager.GameMode.CHAPTER;
        SceneManager.LoadScene(3);
    }
    #endregion

    public void PressStartBackButton()
    {
        modeTitle.SetActive(true);
        backToMainButton.SetActive(true);
        storyButton.SetActive(true);
        chapterButton.SetActive(true);
        sonicButton.SetActive(true);

        levelOneButton.SetActive(false);
        levelTwoButton.SetActive(false);
        levelThreeButton.SetActive(false);
        backToStartButton.SetActive(false);
    }
    public void HardcoreMode()
    {
        GameManager.currentGameMode = GameManager.GameMode.HARDCORE;
        SceneManager.LoadScene(9);
    }

    public void PressMainBackButton()
    {
        startGameButton.SetActive(true);
        tutorialGameButton.SetActive(true);
        creditsGameButton.SetActive(true);
        resourcesGameButton.SetActive(true);
        quitGameButton.SetActive(true);
        title.SetActive(true);

        modeTitle.SetActive(false);
        backToMainButton.SetActive(false);
        storyButton.SetActive(false);
        chapterButton.SetActive(false);
        sonicButton.SetActive(false);
    }
    
    public void PressTutorialButton()
    {
        SceneManager.LoadScene(6);
    }    
    
    public void PressCreditsButton()
    {
        SceneManager.LoadScene(7);
    }
    #region Resources
    public void PressResourcesButton()
    {
        startGameButton.SetActive(false);
        tutorialGameButton.SetActive(false);
        creditsGameButton.SetActive(false);
        resourcesGameButton.SetActive(false);
        quitGameButton.SetActive(false);
        title.SetActive(false);
        
        resources.SetActive(true);
    }
    public void OpenNatlPrevnt()
    {
        Application.OpenURL("https://suicidepreventionlifeline.org/");
    }
    public void AnxietyandDepression()
    {
        Application.OpenURL("https://adaa.org/");
    }
    public void StopBullying()
    {
        Application.OpenURL("https://www.stopbullying.gov/");
    }
    public void TrevorProject()
    {
        Application.OpenURL("https://www.thetrevorproject.org/");
    }
    public void WorkplaceBullying()
    {
        Application.OpenURL("https://www.healthline.com/health/workplace-bullying");
    }
    public void Harassment()
    {
        Application.OpenURL("https://www.eeoc.gov/harassment");
    }
    public void NatlDomesticViolence()
    {
        Application.OpenURL("https://www.thehotline.org/");
    }
    public void AbusiveRelationship()
    {
        Application.OpenURL("https://www.helpguide.org/articles/abuse/domestic-violence-and-abuse.htm");
    }
    public void PressBackButton()
    {
        startGameButton.SetActive(true);
        tutorialGameButton.SetActive(true);
        creditsGameButton.SetActive(true);
        resourcesGameButton.SetActive(true);
        quitGameButton.SetActive(true);
        title.SetActive(true);

        resources.SetActive(false);
    }
    #endregion
    public void PressQuitButton()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}