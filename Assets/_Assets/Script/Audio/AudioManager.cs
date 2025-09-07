using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource musicSource;
    public AudioSource sfxSource;
    // chung
    public AudioClip music;
    [SerializeField] public AudioClip[] attackSound;
    public AudioClip hitSound;
    public AudioClip dashSound;
    public AudioClip deadSound;
    public AudioClip jumpSound;
    [SerializeField] public AudioClip[] footstepSoound;

    // 
    public AudioClip appearSound;
    public AudioClip doubleJumpSound;
    public AudioClip attackUpSound;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        musicSource.clip = music;
        musicSource.Play();
    }

    public void Attack(int Index)
    {
        sfxSource.PlayOneShot(attackSound[Index]);
    }  
    public void Footstep(int Index)
    {
        sfxSource.PlayOneShot(footstepSoound[Index]);
    }
    public void PlaySfx(AudioClip sfx)
    {
        sfxSource.clip = sfx;
        sfxSource.PlayOneShot(sfx);
    }
}
