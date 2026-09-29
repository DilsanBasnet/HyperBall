using UnityEngine;

public class Ball : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set;}

    public float speed = 501f;
    

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
      Invoke(nameof(RandomDelay), 1f);

    }
    private void RandomDelay()
    {

         Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        this.rigidbody.AddForce(force.normalized * this.speed); 
    }
    public void ResetBall()
    {
        this.transform.position = Vector2.zero;
        this.rigidbody.linearVelocity = Vector2.zero;
        Invoke(nameof(RandomDelay), 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Paddle"))
        {
            AudioManagerScript.Instance.PlaySFX(AudioManagerScript.Instance.paddleHitClip);
        }
        else if (collision.gameObject.CompareTag("Brick"))
        {
            AudioManagerScript.Instance.PlaySFX(AudioManagerScript.Instance.brickHitClip);
        }
    }

}
