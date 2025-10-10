using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Transform camera;
    public float rayDistance;
    public GameObject gameOver;
    private CanvasGroup canvasGroup;

    public float tiempoLimite = 0f;
    void Start()
    {
        camera = transform.Find("Main Camera");
        canvasGroup = gameOver.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    void Update()
    {
        Debug.DrawRay(camera.position, camera.forward * rayDistance, Color.black);

        RaycastHit hit;

        if (Physics.Raycast(camera.position, camera.forward, out hit, rayDistance, LayerMask.GetMask("Enemy")))
        {

            tiempoLimite += Time.deltaTime;
            canvasGroup.alpha += Time.deltaTime;

            if (tiempoLimite >= 1)
            {
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
