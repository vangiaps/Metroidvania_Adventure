using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio_Source_Gameobj")]
    public static AudioManager Instance;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Sound_chung_cua_player")]
    public AudioClip music;
    [SerializeField] public AudioClip[] attackSound;
    [SerializeField] public AudioClip[] footstepSoound;
    public AudioClip hitSound;
    public AudioClip dashSound;
    public AudioClip deadSound;
    public AudioClip jumpSound;

    [Header("Sound_rieng_player1")]
    public AudioClip appearSound;
    public AudioClip doubleJumpSound;
    public AudioClip attackUpSound;

    [Header("Sound_chung_cua_enemy (Enemy-Shared)")]
    [SerializeField] private AudioClip DeadSound;
    [SerializeField] private AudioClip HitSound;

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
