
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoWASD : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()
    {
        if (Keyboard.current == null)
        {
            return;
        }

        float horizontal = 0f;
        float vertical = 0f;

        if (Keyboard.current.aKey.isPressed)
        {
            horizontal = -1f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            horizontal = 1f;
        }

        if (Keyboard.current.wKey.isPressed)
        {
            vertical = 1f;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            vertical = -1f;
        }

        transform.position += new Vector3(horizontal, vertical, 0f) * velocidad * Time.deltaTime;
    }
}
