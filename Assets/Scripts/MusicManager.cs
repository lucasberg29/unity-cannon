using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager _instance;

    public AudioSource audioSource;

    public List<AudioClip> allSongs;  
    public AudioClip currentSong;

    public static MusicManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject musicManagerObject = new GameObject("_MusicManager");
                _instance = musicManagerObject.AddComponent<MusicManager>();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);  // Persist this GameObject across scenes
        }
    }

    public void PlayMenuSong()
    {
        if (currentSong.name != "MenuBackground")
        {
            currentSong = allSongs.Find(song => song.name == "MenuBackground");
            audioSource.clip = currentSong;
            audioSource.Play();
        }
    }

    public void PlaySong(string name)
    {
        currentSong = allSongs.Find(song => song.name == name);
    }
}
