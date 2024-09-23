using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource Audio;
    // Start is called before the first frame update
    void Start()
    {
        Audio =GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Audio.volume = PlayerPrefs.GetFloat("Music", 1);
    }
}
