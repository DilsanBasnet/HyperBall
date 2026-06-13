using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}
    public int lifes = 3;
    public int score = 0;
    public int level = 1;

    public Ball ball { get; private set;}
    public PlayerPaddle paddle {get; private set;}
    public Brick[] bricks { get; private set;}

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    public Sprite SelectPaddleSprite { get; set;}
    public Sprite SelectBallSprite { get; set;}
 private void Awake()
    {
       if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnLoadedLevel;

    }
    private void Start()
    {
        FindSceneComponents();
    }
    private void FindSceneComponents()
    {
       this.paddle = FindAnyObjectByType<PlayerPaddle>();
       this.ball = FindAnyObjectByType<Ball>();
       this.bricks = FindObjectsByType<Brick>(FindObjectsInactive.Exclude);
       

       UpdateScoreUI();
       UpdateLivesUI();
       CustomSkins() ;
    }

    public void GameNew()
    {
        this.score = 0;
        this.lifes = 3;
        UpdateScoreUI();
        LevelLoad(1);

    }
    private void  CustomSkins()
    {
        if(this.paddle != null && SelectPaddleSprite != null)
        {
            SpriteRenderer paddleRender = this.paddle.GetComponent<SpriteRenderer>();
            if(paddleRender != null) paddleRender.sprite = SelectPaddleSprite;
        }
        if(this.ball != null && SelectBallSprite != null)
        {
            SpriteRenderer ballRender = this.ball.GetComponent<SpriteRenderer>();
            if(ballRender != null) ballRender.sprite = SelectBallSprite;
        }
    }
    private void LevelLoad(int level)
    {
        this.level = level;
        this.lifes = 3;
        SceneManager.LoadScene("Level" + level);
    }
    private void OnLoadedLevel(Scene scene, LoadSceneMode mode)
    {
        FindSceneComponents();
    }

    public void Hit(Brick brick)
    {
        this.score += 1;
        UpdateScoreUI();

        if(Cleared())
        {
            LevelLoad(this.level + 1);
        }
    }

    private void UpdateScoreUI()
    {
        if(this.scoreText == null)
        {
            this.scoreText = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
        }
        if(this.scoreText != null)
        {
            this.scoreText.text = "Score: " + this.score;
        }
    
    }
    private void UpdateLivesUI()
    {
        if(this.livesText == null)
        {
            this.livesText = GameObject.Find("LivesText")?.GetComponent<TextMeshProUGUI>();

        }
        if(this.livesText != null)
        {
            this.livesText.text = "Lives: " + this.lifes;
        }
    }

    private bool Cleared()
    {
        if(this.bricks == null) return 
        false;

       for (int i = 0; i < this.bricks.Length; i++)
        {
            if(this.bricks[i] != null && this.bricks[i].gameObject.activeInHierarchy && !this.bricks[i].unbreakable)
            {
                return false;
            }
            
        }
         return true;
    }

    public void Death()
    {
        this.lifes--;
        UpdateLivesUI();

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
