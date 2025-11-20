using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Controles : MonoBehaviour
{
    [SerializeField] private GameObject seguir;
    private float tiempo;
    void Start()
    {
        seguir.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;

        if (tiempo >= 4)
        {
            seguir.SetActive(true);
        }
    }

    public void Seguir()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
