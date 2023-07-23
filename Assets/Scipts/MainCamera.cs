using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Ins;
    public AudioSource click;
    public void Play()
    {
        SceneManager.LoadSceneAsync("Game");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Option()
    {
        Ins.SetActive(true);
    }
    public void Back()
    {
        Ins.SetActive(false);
    }
    public void Click()
    {
        click.Play();
    }
}
