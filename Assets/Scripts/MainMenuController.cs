using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject paddleSkinPanel;
    public GameObject ballSkinPanel;
    public GameObject gamemanagerPrefab;

    private void Start()
    {
        if(paddleSkinPanel != null) paddleSkinPanel.SetActive(false);
        if(ballSkinPanel != null) ballSkinPanel.SetActive(false);
        
    }
    public void OpenPaddleSkinPanel()
    {
        paddleSkinPanel.SetActive(true);
        ballSkinPanel.SetActive(false);
    }
    public void OpenBallSkinPanel()
    {
        ballSkinPanel.SetActive(true);
        paddleSkinPanel.SetActive(false);

    }
    public void SelectPaddleSkin(Sprite paddleSprite)
    {
        CheckForGameManager();
        GameManager.Instance.SelectPaddleSprite = paddleSprite; 
    }
    public void SelectBallSkin(Sprite ballSprite)
    {
        CheckForGameManager();
        GameManager.Instance.SelectBallSprite = ballSprite;
    }
   private void CheckForGameManager()
    {
       if(GameManager.Instance == null && gamemanagerPrefab != null)
        {
            Instantiate(gamemanagerPrefab);
        } 
    }

    public void PlayGame()
    {
        CheckForGameManager();
        GameManager.Instance.GameNew();
    }
   
}
