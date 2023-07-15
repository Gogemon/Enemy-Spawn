using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerAnimationSetter))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _shiftedSpeed;

    private SpriteRenderer _playerBody;
    private PlayerAnimationSetter _playerAnimationSetter;

    private void Start()
    {
        _playerBody = GetComponent<SpriteRenderer>();
        _playerAnimationSetter = GetComponent<PlayerAnimationSetter>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _playerBody.flipX = false;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(_shiftedSpeed * Time.deltaTime, 0, 0);
                _playerAnimationSetter.MuveAnimations(2);
            }
            else
            {
                transform.Translate(_speed * Time.deltaTime, 0, 0);
                _playerAnimationSetter.MuveAnimations(1);

            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _playerBody.flipX = true;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(_shiftedSpeed * Time.deltaTime * -1, 0, 0);
                _playerAnimationSetter.MuveAnimations(2);
            }
            else
            {
                transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
                _playerAnimationSetter.MuveAnimations(1);
            }
        }
        else
        {
            _playerAnimationSetter.MuveAnimations(0);
        }
    }
}
