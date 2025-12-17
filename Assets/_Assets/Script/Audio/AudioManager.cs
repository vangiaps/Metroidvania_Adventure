using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio_Source_Gameobj")]
    public static AudioManager Instance;
    public AudioSource sfxSource;

    [Header("Sound_chung_cua_player")]
    [SerializeField] public AudioClip[] attackSound;
    [SerializeField] public AudioClip[] footstepSoound;
    public AudioClip hitSound;
    public AudioClip dashSound;
    public AudioClip deadSound;

    //[Header("Sound_rieng_player")]
    //public AudioClip appearSound;
    //public AudioClip attackUpSound;

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
    }

    public void Attack(int Index)
    {
        sfxSource.PlayOneShot(attackSound[Index]);
    }
    public void Footstep(int Index)
    {
        sfxSource.PlayOneShot(footstepSoound[Index]);
    }
    public virtual void PlaySfx(AudioClip sfx)
    {
        if (sfx != null)
        {
            sfxSource.PlayOneShot(sfx);
        }
    }
}
