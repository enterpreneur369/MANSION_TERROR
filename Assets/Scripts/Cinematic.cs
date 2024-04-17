using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Cinematic : MonoBehaviour
{
    // Se declaran variables privadas para el reproductor de video y la fuente de audio.
    private VideoPlayer _videoPlayer;
    private AudioSource _audioSource;

    // Se permite asignar desde el editor de Unity el nombre del archivo de video a reproducir.
    [SerializeField] private string videoFileName;

    // Awake se llama cuando el script se carga.
    void Awake()
    {
        // Se busca en los componentes del objeto un AudioSource y un VideoPlayer y se asignan a las variables.
        _audioSource = FindObjectOfType<AudioSource>();
        _videoPlayer = GetComponent<VideoPlayer>();
        // Se inicia la reproducción del audio.
        _audioSource.Play();
        // Se construye la ruta completa del archivo de video a reproducir.
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
        // Se asigna la ruta del video al reproductor y se inicia su reproducción.
        _videoPlayer.url = videoPath;
        _videoPlayer.Play();
    }

    // Este método se llama en cada frame.
    // Cuando el video termina, detiene el audio y carga la escena llamada "World".
    void CheckOver(VideoPlayer videoPlayer)
    {
        _audioSource.Stop();
        SceneManager.LoadScene("World");
    }
}
