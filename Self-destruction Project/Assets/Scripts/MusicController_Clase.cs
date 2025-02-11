using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController_Clase : MonoBehaviour
{
    private AudioSource _audioSource;
    public bool _isPlaying;

    private void Awake()
    {
        MusicController_Clase[] objects = FindObjectsOfType<MusicController_Clase>();
        _audioSource = GetComponent<AudioSource>();

        _audioSource.Play();

        if (objects.Length > 1)
        {
            Destroy(objects[1].gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }
}
