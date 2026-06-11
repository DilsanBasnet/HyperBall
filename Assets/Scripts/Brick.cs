using UnityEngine;

public class Brick : MonoBehaviour
{
    public int BrickHealth { get; private set;}

    public SpriteRenderer spriteRenderer { get; private set;}

    public Sprite[] states;

    public bool unbreakable;

    public int Point = 1;

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    private void Start()
    {
       ResetBrick();
    }

    private void Hit()
    {
        if(this.unbreakable)
        {
            return;
        }
        this.BrickHealth--;

        if(this.BrickHealth <= 0)
        {
            this.gameObject.SetActive(false);
        }
        else if (this.states.Length > 0)
        {
             this.spriteRenderer.sprite = this.states[this.BrickHealth -1];
        
        }   
        FindAnyObjectByType<GameManager>().Hit(this);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball") || collision.gameObject.name.Contains("Ball"))
        {
            Hit();
        }
    }
    public void ResetBrick()
    {
        this.gameObject.SetActive(true);
        if(!this.unbreakable)
        {
            this.BrickHealth = this.states.Length;
            if(this.states.Length > 0 )
            {
                this.spriteRenderer.sprite = this.states[this.BrickHealth - 1];
            }
        }
        else
        {
            this.BrickHealth = 100;
        }
    }




}
