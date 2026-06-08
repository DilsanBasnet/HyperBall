using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPaddle : MonoBehaviour
{
    public Vector2 direction { get; private set;}
    public new Rigidbody2D rigidbody { get; private set; }
    public float speed = 30f;      
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

}
