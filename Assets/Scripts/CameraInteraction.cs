using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Transform camera;
    public float rayDistance;
    public GameObject gameOver;

    public float tiempoLimite = 1f;
    void Start()
    {
        camera = transform.Find("Main Camera");
        gameOver.SetActive(false);
    }

    void Update()
    {
        Debug.DrawRay(camera.position, camera.forward * rayDistance, Color.black);

        RaycastHit hit;

        if (Physics.Raycast(camera.position,camera.forward, out hit, rayDistance, LayerMask.GetMask("Enemy"))) 
        {
            tiempoLimite -= Time.deltaTime;
            if (tiempoLimite <= 0)
            {
                gameOver.SetActive(true);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            tiempoLimite = 1f;
        }
    }
}
