using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Cinematic : MonoBehaviour
{
    private VideoPlayer _videoPlayer;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private string videoFileName;

    void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();

        _audioSource.Play();

        // Suscribir el método CheckOver al evento loopPointReached del VideoPlayer
        _videoPlayer.loopPointReached += CheckOver;

        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
        _videoPlayer.url = videoPath;
        _videoPlayer.Play();

        // Se asigna la ruta del video al reproductor y se inicia su reproducción.
        _videoPlayer.url = videoPath;
        _videoPlayer.Play();
    }

    public void CheckOver(VideoPlayer vp)
    {
        _audioSource.Stop();
        SceneManager.LoadScene("World");
    }
}