using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CooldownTimer : MonoBehaviour
{
    [SerializeField] private VampirismTimer _mechanic;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _mechanic.SendingTimerInfo += ShowTimer;
    }

    private void OnDisable()
    {
        _mechanic.SendingTimerInfo += ShowTimer;
    }

    private void ShowTimer(int value)
    {
        _text.text = "Кулдаун: " + value;
    }
}
