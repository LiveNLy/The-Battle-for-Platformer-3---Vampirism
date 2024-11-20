using UnityEngine;

public class VampireAuraImage : MonoBehaviour
{
    [SerializeField] private Character character;

    private void Update()
    {
        transform.position = character.transform.position;
    }
}
