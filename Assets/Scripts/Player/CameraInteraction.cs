using UnityEngine;
using UnityEngine.SceneManagement;

public class CamaraInteraction : MonoBehaviour
{
    private Transform cameraMain;
    public float rayDistance;
    public GameObject gameOver;
    private CanvasGroup canvasGroup;


    public float tiempoLimite = 0f;
    void Start()
    {
        cameraMain = transform.Find("Main Camera");
        canvasGroup = gameOver.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    void Update()
    {
        Debug.DrawRay(cameraMain.position, cameraMain.forward * rayDistance, Color.black);

        RaycastHit hit;

        if (Physics.Raycast(cameraMain.position, cameraMain.forward, out hit, rayDistance, LayerMask.GetMask("Enemy")))
        {

            tiempoLimite += Time.deltaTime;
            canvasGroup.alpha += Time.deltaTime;

            if (tiempoLimite >= 1)
            {
                Metricas.Instance.RegistrarEvento("Muertes", 1f);

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            canvasGroup.alpha = 0;
            tiempoLimite = 0f;
        }
    }
}
