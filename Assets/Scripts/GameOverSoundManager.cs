using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSoundManager : MonoBehaviour
{
    public static GameOverSoundManager Instance;
    public AudioClip gameOverSound;

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
        audioSource.clip = gameOverSound; // Устанавливаем аудиоклип здесь
    }

    public void PlayGameOverSound()
    {
        audioSource.PlayOneShot(gameOverSound);
    }
}