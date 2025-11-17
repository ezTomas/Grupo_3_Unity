using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void MenuPrincipal()
    {
        Metricas.Instance.Guardar();
        Debug.Log("Guardado");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
