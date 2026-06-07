using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lifes = 3;
    public int score = 0;
    public int level = 1;
 private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

    }
    private void Start()
    {
        GameNew();
    }

    private void GameNew()
    {
        this.score = 0;
        this.lifes = 3;
        LevelLoad(1);

    }
    private void LevelLoad(int level)
    {
        this.level = level;
        SceneManager.LoadScene("Level" + level);

        
    }
}
