using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public void Back()
    {
        // Load the previous scene in the build index
        int previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        
        // If the previous scene index is less than 0, loop back to the last scene
        if (previousSceneIndex < 0)
        {
            previousSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        }
        
        SceneManager.LoadScene(previousSceneIndex);
    }
}
