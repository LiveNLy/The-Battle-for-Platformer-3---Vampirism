using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VampirismTimer : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _auraImage;
    [SerializeField] private int _vampirismTimer = 6;
    [SerializeField] private int _cooldownTimer = 4;

    private WaitForSeconds _wait = new WaitForSeconds(1);
    private Coroutine _coroutine;

    public event Action<int> SendingInfo;
    public event Action<int> SendingTimerInfo;
    public event Action<bool> SendingTimerEnabled;

    private void Awake()
    {
        SendingTimerInfo?.Invoke(_cooldownTimer);
        SendingInfo?.Invoke(_vampirismTimer);
    }

    private void OnEnable()
    {
        _button?.onClick.AddListener(CoroutineStarter);
    }

    private void OnDisable()
    {
        _button?.onClick.RemoveListener(CoroutineStarter);
    }

    private void CoroutineStarter()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(VampirismCoroutine());
        }
    }

    private IEnumerator CouldownCoroutine()
    {
        int cooldownTimer = _cooldownTimer;

        while (cooldownTimer != 0)
        {
            cooldownTimer--;
            SendingTimerInfo?.Invoke(cooldownTimer);

            yield return _wait;
        }

        SendingTimerInfo?.Invoke(_cooldownTimer);
        SendingInfo?.Invoke(_vampirismTimer);
        _coroutine = null;
    }

    private IEnumerator VampirismCoroutine()
    {
        SendingTimerEnabled?.Invoke(true);
        int vampirismTimer = _vampirismTimer;
        _auraImage.gameObject.SetActive(true);

        while (vampirismTimer != 0)
        {
            vampirismTimer--;
            SendingInfo?.Invoke(vampirismTimer);

            yield return _wait;
        }

        SendingTimerEnabled?.Invoke(false);
        _auraImage.gameObject.SetActive(false);

        yield return CouldownCoroutine();
    }
}