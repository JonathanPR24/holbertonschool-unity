using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;

    void Start()
    {
        startTime = Time.time; // Record the starting time
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime; // Calculate elapsed time

        // Calculate minutes, seconds, and milliseconds
        int minutes = (int)(elapsedTime / 60);
        int seconds = (int)(elapsedTime % 60);
        int milliseconds = (int)((elapsedTime * 100) % 100);

        // Format the time string
        string timeString = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);

        // Update the Timer Text object
        if (timerText != null)
        {
            timerText.text = timeString;
        }
    }
}
