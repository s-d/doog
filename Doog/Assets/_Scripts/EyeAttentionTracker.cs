using UnityEngine;
using Tobii.EyeTracking;

public class EyeAttentionTracker : MonoBehaviour
{
    private bool TobiiAvailable = false;
    private float LastAttentionTimestamp;
    private const float threshold = 5f; // Maybe make this variable between 3-6s ? Make it risky!
    private bool dead = false;

    // Use this for initialization
    void Start()
    {
        // Should firstly check the engine is available, with
        // EyeTrackingHost.GetEngineAvailability , but apparently it doesn't exist.
        Debug.Log("Initialising eye tracking");
        EyeTracking.Initialize();

        // Wait while the tracker is pending, and then make sure it went into tracking mode
        while (EyeTrackingHost.GetInstance().EyeTrackingDeviceStatus == DeviceStatus.Pending) { }
        if (EyeTrackingHost.GetInstance().EyeTrackingDeviceStatus == DeviceStatus.Tracking)
        {
            TobiiAvailable = true;
        }
        
        LastAttentionTimestamp = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!TobiiAvailable) { return; } // Don't even bother - we're not ready or such

        // Don't process if dead. This should be swapped out when there's some
        // game-wide marker of alive/dead we can use.
        if (dead) { return; }

        GazePoint gazePoint = EyeTracking.GetGazePoint();
        if (gazePoint.IsValid)
        {
            // If gaze within the 80% boundaries, update the timestamp
            // to show the user is up to date
            if (gazePoint.Screen.x > 0.2 * Screen.width
                && gazePoint.Screen.x < 0.8 * Screen.width
                && gazePoint.Screen.y > 0.2 * Screen.height
                && gazePoint.Screen.y < 0.8 * Screen.height)
            {
                LastAttentionTimestamp = Time.time;
            }

            // Check for gaze timeout or staleness (eye tracking lost, for example)
            // if we're done, trigger game over
            if (Time.time - LastAttentionTimestamp > threshold
                || Time.time - gazePoint.Timestamp > threshold)
            {
                Debug.Log("Player failed to pay attention and was killed");
                // Trigger the stabbing here
                dead = true;
            }
        }
    }
}
