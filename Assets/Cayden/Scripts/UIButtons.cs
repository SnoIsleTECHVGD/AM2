using UnityEngine.SceneManagement;
using UnityEngine;

public class UIButtons : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Main");
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
}
