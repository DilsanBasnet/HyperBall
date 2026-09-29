using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
   public static AudioManagerScript Instance;

   [SerializeField] private AudioSource bgmSource;
   [SerializeField] private AudioSource sfxSource;

   public AudioClip bgmClip;
   public AudioClip paddleHitClip;
   public AudioClip brickHitClip;
   public AudioClip gameOverClip;

    private void Awake()
    {
        if(Instance == null)
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
             else
            {
                Destroy(gameObject);
                return;

            }
        }}


    private void Start()
    {
        if(bgmClip != null)
        {
            bgmSource.clip = bgmClip;
            bgmSource.loop = true;
            bgmSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if(clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}
