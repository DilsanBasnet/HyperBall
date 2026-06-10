using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lifes = 3;
    public int score = 0;
    public int level = 1;

    public Ball ball { get; private set;}
    public PlayerPaddle paddle {get; private set;}
 private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnLoadedLevel;

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
    private void OnLoadedLevel(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindAnyObjectByType<Ball>() ;
        this.paddle = FindAnyObjectByType<PlayerPaddle>();
        
           }

    public void Hit(Brick brick)
    {
        this.score += brick.Point;
    }
    public void Death()
    {
        this.lifes--;

        if(lifes > 0)
        {
            ResetLevel();
        }
        else
        {
            GameOver();
        }
    }
    private void ResetLevel()
    {
        this.ball.ResetBall();
        this.paddle.ResetPaddle();
    }
    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
