using UnityEngine.SceneManagement;
using UnityEngine;

public class UIButtons : MonoBehaviour
{
    GameObject newObject;
    public void Play()
    {
        SceneManager.LoadScene("Thomas");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Resume()
    {
        GameObject pause =  GameObject.Find("Pause");
        pause.GetComponent<Pause>().unPause();
    }
    public void Pause()
    {
        GameObject pause = GameObject.Find("Pause");
        pause.GetComponent<Pause>().Pausening();
    }
    public void Back()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }
}
