using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class BackgroundCheinger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _background;

    private Color _blackColor;
    private Color _currentColor;

    private bool _isColorChenged;

    private void Start()
    {
        _background = GetComponent<SpriteRenderer>();
        _blackColor = Color.black;
        _currentColor = _background.color;
    }

    public void ChangeDarkenBackground()
    {
        _background.color = _isColorChenged ? _currentColor : _blackColor;
        _isColorChenged = !_isColorChenged;
    }
}
