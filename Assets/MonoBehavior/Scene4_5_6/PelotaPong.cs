
using UnityEngine;

public class PelotaPong : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float velocidad = 8f;
    public float velocidadMaxima = 12f;
    public float velocidadMinima = 8f;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        float direccionX = Random.value < 0.5f ? -1f : 1f;
        float direccionY = Random.value < 0.5f ? -0.5f : 0.5f;

        Vector2 direccion = new Vector2(direccionX, direccionY).normalized;
        rigidbody2D.linearVelocity = direccion * velocidad;
    }


void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Jugadores"))
    {
        float direccionX = rigidbody2D.linearVelocity.x >= 0 ? -1f : 1f;

        float impacto = transform.position.y - collision.transform.position.y;
        impacto = Mathf.Clamp(impacto, -1f, 1f);

        Vector2 direccion = new Vector2(direccionX, impacto).normalized;

        rigidbody2D.linearVelocity = direccion * velocidad;
    }
}


    void FixedUpdate()
    {
        float magnitud = rigidbody2D.linearVelocity.magnitude;

        if (magnitud > 0f && magnitud < velocidadMinima)
        {
            rigidbody2D.linearVelocity =
                rigidbody2D.linearVelocity.normalized * velocidadMinima;
        }
        else if (magnitud > velocidadMaxima)
        {
            rigidbody2D.linearVelocity =
                rigidbody2D.linearVelocity.normalized * velocidadMaxima;
        }
    }
}
