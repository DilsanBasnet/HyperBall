using UnityEngine;
using UnityEngine.SceneManagement;

public class gameovercontroller : MonoBehaviour
{
   public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
        
            }

            public void ExitGame()
    {
        Debug.Log("Game Exits...");
        Application.Quit();
        
    }
}
