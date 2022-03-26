using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    public static bool levelCompleted;
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger");
        if (col.tag == "Player")
        {
            Debug.Log("Player Detected");
            levelCompleted = true;
        }
    }
}
