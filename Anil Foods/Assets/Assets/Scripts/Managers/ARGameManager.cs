using UnityEngine;
using Zappar;

public class ARGameManager : MonoBehaviour
{
    [Header("Zappar")]
    [SerializeField] private ZapparInstantTrackingTarget instantTracker;

    [Header("Gameplay")]
    public WorldGenerator worldGenerator;
    public Transform player;

    private bool anchored = false;

    void Update()
    {
        if (!anchored)
        {
            SetupARWorld();
        }
    }

    void SetupARWorld()
    {
        instantTracker.PlaceTrackerAnchor();
        anchored = true;

        player.SetParent(instantTracker.transform, false);
        player.localPosition = Vector3.zero;
        player.localRotation = Quaternion.identity;

        worldGenerator.StartWorld(instantTracker.transform);
    }
}
