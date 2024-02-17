using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public Timer timerScript; // Reference to the Timer script attached to the player
    public UnityEngine.UI.Text timerText; // Reference to the Text component of the timer

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Stop the timer
            if (timerScript != null)
            {
                timerScript.enabled = false;
            }

            // Increase text size and change color to green
            if (timerText != null)
            {
                timerText.fontSize = 60;
                timerText.color = Color.green;
            }
        }
    }
}
