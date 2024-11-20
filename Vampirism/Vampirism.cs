using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _healthExchange;
    [SerializeField] private VampirismTimer _timer;

    private bool _isRunning = false;

    private void OnEnable()
    {
        _timer.SendingTimerEnabled += VampirismSwitch;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy) && _isRunning == true)
        {
            enemy.GetHealth().LoseHealth(_healthExchange);
            _health.Heal(_healthExchange);
        }
    }

    private void Update()
    {
        transform.position = _health.transform.position;
    }

    private void OnDisable()
    {
        _timer.SendingTimerEnabled -= VampirismSwitch;
    }

    private void VampirismSwitch(bool switcher)
    {
        _isRunning = switcher;
    }
}