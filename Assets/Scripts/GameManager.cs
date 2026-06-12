using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int lifes = 3;
    public int score = 0;
    public int level = 1;

    public Ball ball { get; private set;}
    public PlayerPaddle paddle {get; private set;}
    public Brick[] bricks { get; private set;}
    public TextMeshProUGUI scoreText;
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
        UpdateScoreUI();
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
        this.bricks = FindObjectsByType<Brick>();

        this.scoreText = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
        UpdateScoreUI(); }

    public void Hit(Brick brick)
    {
        this.score += brick.Point;
        UpdateScoreUI();
        if(Cleared())
        {
            LevelLoad(this.level + 1);
        }
    }

    private void UpdateScoreUI()
    {
        if(this.scoreText != null)
        {
            this.scoreText.text = "Score: " + this.score;
        }
    
    }

    private bool Cleared()
    {
       for (int i = 0; i < this.bricks.Length; i++)
        {
            if(this.bricks[i].gameObject.activeInHierarchy && !this.bricks[i].unbreakable)
            {
                return false;
            }
            
        }
         return true;
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
