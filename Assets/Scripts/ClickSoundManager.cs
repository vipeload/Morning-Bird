using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSoundManager : MonoBehaviour
{
    public static ClickSoundManager Instance;
    public AudioClip clickSound;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clickSound; // Устанавливаем аудиоклип здесь
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }
}