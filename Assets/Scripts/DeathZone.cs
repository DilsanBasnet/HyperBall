using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball") || collision.gameObject.name.Contains("Ball"))
        {
            FindAnyObjectByType<GameManager>().Death();
        }
    }

    public void TriggerGameOver()
    {
        AudioManagerScript.Instance.PlaySFX(AudioManagerScript.Instance.gameOverClip);
    }

}
