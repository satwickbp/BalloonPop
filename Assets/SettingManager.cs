using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public Slider SoundSlider;
    public Slider MusicSlider;
    // Start is called before the first frame update
    void Start()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("Music",0);
        SoundSlider.value = PlayerPrefs.GetFloat("Sound",0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("Music", MusicSlider.value);
        PlayerPrefs.SetFloat("Sound", SoundSlider.value);

        //Debug.Log("Music" + PlayerPrefs.GetFloat("Music"));
        //Debug.Log("Sound" + PlayerPrefs.GetFloat("Sound"));
    }
}
