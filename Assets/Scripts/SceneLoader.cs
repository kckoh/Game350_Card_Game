using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void SceneLoad()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }

    public void Load2By3()
    {
        SceneManager.LoadScene("2By3");
    }

    public void Load3By4()
    {
        SceneManager.LoadScene("3By4");
    }

    public void Load4By4()
    {
        SceneManager.LoadScene("4By4");
    }

    // function to exit the application
    public void ExitGame()
    {
        Application.Quit();
    }

}
