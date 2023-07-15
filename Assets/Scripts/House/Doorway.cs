using UnityEngine;

public class Doorway : MonoBehaviour
{
    private const string EntranceDoor = "Entrance";
    private const string ExitDoor = "Exit";

    [HideInInspector] public GameObject Entrance;
    [HideInInspector] public GameObject Exit;

    private Signaling _signaling;

    private void Awake()
    {
        Entrance = gameObject.transform.Find(EntranceDoor).gameObject;
        Exit = gameObject.transform.Find(ExitDoor).gameObject;

        _signaling = GetComponentInChildren<Signaling>();
    }

    public void ToggleSignalingState(bool isDoorExit)
    {
        _signaling.StartVolumeChanger(isDoorExit);
    }
}
