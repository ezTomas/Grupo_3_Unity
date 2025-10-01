using UnityEngine;

public class NumeroEncontrado : MonoBehaviour
{
    public string numero; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            UIManager.Instance.MostrarNumero(numero);
            gameObject.SetActive(false);
        }
    }
}
