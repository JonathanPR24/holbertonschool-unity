using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    private bool playerExited = false; // Flag to track if the player has exited the trigger

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !playerExited)
        {
            playerExited = true; // Player has exited the trigger
            Timer timerScript = other.GetComponent<Timer>();
            if (timerScript != null)
            {
                timerScript.enabled = true; // Enable the Timer script on the Player
            }
        }
    }
}
