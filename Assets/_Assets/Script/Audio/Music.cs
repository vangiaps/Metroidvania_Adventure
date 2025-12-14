using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource musicSource;
    [SerializeField] AudioClip music;

    private void Start()
    {
        musicSource.clip = music;
        musicSource.Play();
    }
}
