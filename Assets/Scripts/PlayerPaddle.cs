using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPaddle : MonoBehaviour
{
    public Vector2 direction { get; private set;}
    public new Rigidbody2D rigidbody { get; private set; }
    public float speed = 30f;  
    public float MaxBallBounceAngles = 75f;    
    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();


    }

    private void Update()
    {
        if(Keyboard.current != null)
        {
            if(Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                this.direction = Vector2.left;
            }
            else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                this.direction = Vector2.right;
            }
             else
            {
                this.direction = Vector2.zero;
                
            }
        }
    }
    private void FixedUpdate()
    {
        if(this.direction != Vector2.zero)
        {
            this.rigidbody.AddForce(this.direction * this.speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if(ball != null)
        {
            Vector3 PaddlePosition = this.transform.position;
            Vector2 ContactPoint = collision.GetContact(0).point;

            float Offset = PaddlePosition.x - ContactPoint.x;
            float Width = collision.otherCollider.bounds.size.x / 2;
            float CurrentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidbody.linearVelocity);
            float BounceAngle = (Offset / Width) * this.MaxBallBounceAngles;
            float UpgradeAngle =  Mathf.Clamp(CurrentAngle + BounceAngle, -this.MaxBallBounceAngles, this.MaxBallBounceAngles);

            Quaternion Rotation = Quaternion.AngleAxis(UpgradeAngle, Vector3.forward);
            
            ball.rigidbody.linearVelocity = Rotation * Vector2.up * ball.rigidbody.linearVelocity.magnitude;
        } 
        
    }

    public void ResetPaddle()
    {
        this.transform.position = new Vector2(0f, this.transform.position.y);
        this.rigidbody.position = Vector2.zero;
    }

}
