using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Principal : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    [SerializeField] private TMP_InputField inputName;

    private string nameString;
    public void Start()
    {
        panel.SetActive(false);
    }

    public void Jugar()
    {
        panel.SetActive(true);
    }

    public void Confirmar()
    {
        nameString = inputName.text;
        Metricas.Instance.IniciarSesion(nameString);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }



}
