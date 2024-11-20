using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VampirismSlider : MonoBehaviour
{
    [SerializeField] private VampirismTimer _mechanic;

    private Slider _vampirismSlider;

    private void Awake()
    {
        _vampirismSlider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _mechanic.SendingInfo += ShowTimer;
    }

    private void OnDisable()
    {
        _mechanic.SendingInfo += ShowTimer;
    }

    private void ShowTimer(int value)
    {
        _vampirismSlider.value = value;
    }
}
