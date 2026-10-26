
using UnityEngine;

public class FinalizarPartida : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FinPartida"))
        {
            Destroy(gameObject);
            Debug.Log("Partida terminada");
        }
    }
}
