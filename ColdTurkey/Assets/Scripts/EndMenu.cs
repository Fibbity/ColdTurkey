using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField]
    private Button levelOneButton;
    [SerializeField]
    private Button levelTwoButton;
    [SerializeField]
    private Button levelThreeButton;

    public void LateUpdate()
    {
        if (GameManager.levelCount == 4)
        {
            //StoryMode
            if (GameManager.currentGameMode == GameManager.GameMode.STORY)
            {
                Debug.Log("You are on Story Mode");
                switch (GameManager.previouslevelCount)
                {
                    case 1:
                        levelOneButton.interactable = true;
                        levelTwoButton.interactable = true;
                        levelThreeButton.interactable = false;
                        break;
                    case 2:
                        levelOneButton.interactable = true;
                        levelTwoButton.interactable = true;
                        levelThreeButton.interactable = true;
                        break;
                    case 3:
                        levelOneButton.interactable = true;
                        levelTwoButton.interactable = true;
                        levelThreeButton.interactable = true;
                        break;
                    case 6:
                        levelOneButton.interactable = true;
                        levelTwoButton.interactable = false;
                        levelThreeButton.interactable = false;
                        break;
                    default:
                        break;
                }
            }
            //ChapterMode
            else
            {
                levelOneButton.interactable = true;
                levelTwoButton.interactable = true;
                levelThreeButton.interactable = true;
            }
        }

        //Lose Menu
        else
        {
            Debug.Log("You lost");
            //StoryMode
            if (GameManager.currentGameMode == GameManager.GameMode.STORY)
            {
                switch (GameManager.previouslevelCount)
                {
                    case 1:
                        levelOneButton.interactable = true;
                        levelTwoButton.interactable = false;
                        levelThreeButton.interactable = false;
                        break;
                    case 2:
                        levelOneButton.interactable = true;
                        levelTwoButton.interactable = true;
                        levelThreeButton.interactable = false;
                        break;
                    case 3:
                        levelOneButton.interactable = true;
                        levelTwoButton.interactable = true;
                        levelThreeButton.interactable = true;
                        break;
                    default:
                        break;
                }
            }
            //ChapterMode
            else
            {
                levelOneButton.interactable = true;
                levelTwoButton.interactable = true;
                levelThreeButton.interactable = true;
            }
        }
    }
    public void PressLevel1()
    {
        SceneManager.LoadScene(1);
    }    
    public void PressLevel2()
    {
        SceneManager.LoadScene(2);
    }    
    public void PressLevel3()
    {
        SceneManager.LoadScene(3);
    }

    public void PressMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
