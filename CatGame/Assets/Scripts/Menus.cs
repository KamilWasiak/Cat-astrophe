using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menus : MonoBehaviour
{

    public AudioMixer volMixer;
    public Slider volSlider;


    public void Start()
    {
        volSlider.value = PlayerPrefs.GetFloat("MusicVol", 1f);
        volMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVol"));
    }

    public void ChangeVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVol", volume);
        volMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVol"));
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
