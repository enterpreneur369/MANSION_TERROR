using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Cinematic : MonoBehaviour
{
    private VideoPlayer _videoPlayer;

    public AudioSource _AudioSource;
    // Start is called before the first frame update
    void Awake()
    {
        _videoPlayer = FindObjectOfType<VideoPlayer>();
        _videoPlayer.Play();
        _videoPlayer.loopPointReached += CheckOver;
        _AudioSource = FindObjectOfType<AudioSource>();
        _AudioSource.Play();
    }

    // Update is called once per frame
    void CheckOver(VideoPlayer videoPlayer)
    {
        _AudioSource.Stop();
        SceneManager.LoadScene("World");
    }
}
