using UnityEngine;

public class PuertaTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // El jugador debe tener el tag "Player"
        {
            CodigoEscape codigoEscape = FindObjectOfType<CodigoEscape>();
            if (codigoEscape != null)
            {
                codigoEscape.IntentarAbrirPuerta();
            }
        }
    }
}