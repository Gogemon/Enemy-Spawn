using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimationSetter : MonoBehaviour
{
    private const string SpeedAnimator = "Speed";

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void MuveAnimations(int animationNumber)
    {
        _animator.SetInteger(SpeedAnimator, animationNumber);
    }
}
