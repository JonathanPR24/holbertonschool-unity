using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Level01()
    {
        SceneManager.LoadScene("level01");
    }

    public void Level02()
    {
        SceneManager.LoadScene("level02");
    }

    public void Level03()
    {
        SceneManager.LoadScene("level03");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void ExitGame()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
