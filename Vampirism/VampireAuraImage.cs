using UnityEngine;

public class VampireAuraImage : MonoBehaviour
{
    [SerializeField] private Character _character;

    private void Update()
    {
        transform.position = _character.transform.position;
    }
}
