
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class MovimentoNewInput : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;
    public float fuerzaSalto = 5f;

    [Header("Detección de suelo")]
    public LayerMask capaSuelo;

    [Header("Colores")]
    public Color colorOriginal = Color.white;
    public Color colorNuevo = Color.green;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private bool enSuelo;
    private float movimientoHorizontal;
    private bool saltoSolicitado;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        // FUERZA LOS COLORES
        colorOriginal.a = 1f;
        colorNuevo.a = 1f;

        AplicarColor(colorOriginal);
    }

    void Update()
    {
        movimientoHorizontal = 0f;

        if (Keyboard.current == null)
            return;

        if (Keyboard.current.leftArrowKey.isPressed)
            movimientoHorizontal = -1f;

        if (Keyboard.current.rightArrowKey.isPressed)
            movimientoHorizontal = 1f;

        if (Keyboard.current.spaceKey.wasPressedThisFrame && enSuelo)
            saltoSolicitado = true;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(
            movimientoHorizontal * velocidad,
            rb.linearVelocity.y
        );

        // ESTA EN EL SUELO?
        enSuelo = false;

        ContactPoint2D[] contactos = new ContactPoint2D[10];
        int cantidad = boxCollider.GetContacts(contactos);

        for (int i = 0; i < cantidad; i++)
        {
            ContactPoint2D contacto = contactos[i];

            if (Vector2.Dot(contacto.normal, Vector2.up) > 0.5f)
            {
                Collider2D otro = contacto.collider;

                if (otro != null &&
                    (capaSuelo.value & (1 << otro.gameObject.layer)) != 0)
                {
                    enSuelo = true;
                    break;
                }
            }
        }

        // LIMITADOR DE SALTO: SOLO EN EL SUELO
        if (saltoSolicitado && enSuelo)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                fuerzaSalto
            );

            enSuelo = false;
        }

        saltoSolicitado = false;

        // EVITA ERROR DE INVISIBILIDAD
        AplicarColor(enSuelo ? colorNuevo : colorOriginal);
    }

    void AplicarColor(Color color)
    {
        color.a = 1f;
        spriteRenderer.color = color;
    }
}
