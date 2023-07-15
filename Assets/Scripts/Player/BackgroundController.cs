using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private BackgroundCheinger _backgroundCheinger;

    private void Start()
    {
        _backgroundCheinger = GetComponentInChildren<BackgroundCheinger>();
    }

    public void ChengeBackground()
    {
        _backgroundCheinger.ChangeDarkenBackground();
    }
}
