// NO USAR
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerza = 5f;

    public Rigidbody2D rigidbody2D;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody2D.AddForce(Vector2.up * fuerza);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2D.linearVelocity = Vector2.right * velocidad;
        }
    }
}
