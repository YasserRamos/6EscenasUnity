using UnityEngine;

public class LimiteSalto : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float impulsoMaximo = 8f;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (rigidbody2D.linearVelocity.y > impulsoMaximo)
        {
            rigidbody2D.linearVelocity = new Vector2(
                rigidbody2D.linearVelocity.x,
                impulsoMaximo
            );
        }
    }
}