using System.Collections;
using UnityEngine;
using System.Linq;

public class Transition : MonoBehaviour
{
    private const string ExitTag = "Exit";

    [SerializeField] private Transition _secondDoor;

    private Coroutine _cooldownCoroutine;
    private Doorway _doorway;

    private float _transitionTime;
    private float _transitionTimeCooldown = 1;
    private bool _isExit;

    private void Start()
    {
        var parent = gameObject.transform.parent.gameObject;
        _doorway = parent.GetComponent<Doorway>();

        _secondDoor = _doorway.GetComponentsInChildren<Transition>().FirstOrDefault(transition => transition != this);

        _isExit = this.CompareTag(ExitTag) ? true : false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (Input.GetKey(KeyCode.E) && _transitionTime <= 0)
            {
                _secondDoor.SetCooldown();
                _doorway.ToggleSignalingState(_isExit);

                BackgroundController backgroundController = player.GetComponent<BackgroundController>();
                backgroundController.ChengeBackground();

                player.transform.position = _secondDoor.transform.position;
            }
        }
    }

    public void SetCooldown()
    {
        _transitionTime = _transitionTimeCooldown;
        _cooldownCoroutine = StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        bool isCooldownRun = true;

        while (isCooldownRun)
        {
            _transitionTime -= Time.deltaTime;

            if (_transitionTime <= 0)
            {
                StopCooldownCoroutine();
            }

            yield return null;
        }
    }

    private void StopCooldownCoroutine()
    {
        StopCoroutine(_cooldownCoroutine);
    }
}
