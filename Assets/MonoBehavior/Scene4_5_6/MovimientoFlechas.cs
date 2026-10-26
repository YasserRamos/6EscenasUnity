using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoFlechas : MonoBehaviour
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

        if (Keyboard.current.upArrowKey.isPressed)
        {
            vertical = 1f;
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            vertical = -1f;
        }

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            horizontal = -1f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            horizontal = 1f;
        }

        transform.position += new Vector3(horizontal, vertical, 0f)
            * velocidad * Time.deltaTime;
    }
}