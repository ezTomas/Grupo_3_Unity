using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None; 
    }

    public void MenuPrincipal()
    {
        Metricas.Instance.Guardar();
        Debug.Log("Guardado");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

    }

    public void Reintentar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
