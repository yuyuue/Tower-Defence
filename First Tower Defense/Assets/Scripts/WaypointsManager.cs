using UnityEngine;

public class WaypointsManager : MonoBehaviour
{
    public static WaypointsManager Instance;

    public Transform[] waypoints;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
