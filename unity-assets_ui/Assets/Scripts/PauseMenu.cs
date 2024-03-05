using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool isPaused = false;
    private float previousTimeScale;

    void Start()
    {
        // Ensure that the pauseCanvas is initially inactive
        if (pauseCanvas != null)
            pauseCanvas.SetActive(false);

        // Make the cursor visible at the start
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        // Check for pause input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        // Pause the game
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        isPaused = true;

        // Activate the pause canvas
        if (pauseCanvas != null)
            pauseCanvas.SetActive(true);

        // Cursor remains visible
    }

    public void Resume()
    {
        // Unpause the game
        Time.timeScale = previousTimeScale;
        isPaused = false;

        // Deactivate the pause canvas
        if (pauseCanvas != null)
            pauseCanvas.SetActive(false);

        // Cursor remains visible
    }

    public void Restart()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        // Load the MainMenu scene
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        // Load the Options scene
        SceneManager.LoadScene("Options");
    }
}
