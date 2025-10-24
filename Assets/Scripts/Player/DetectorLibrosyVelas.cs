using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DetectorLibrosyVelas : MonoBehaviour
{
    private Transform cameraMain;
    public float rayDistance;

    public TMP_Text numeroVelasUI;
    public TMP_Text numeroLibrosUI;

    public Image libro;
    public Image vela;

    private int numeroVelas = 0;
    private int numeroLibros = 0;

    public Color colorAro = Color.green;

    void Start()
    {
        cameraMain = transform.Find("Main Camera");

        numeroLibrosUI.text = numeroLibros.ToString();
        numeroVelasUI.text = numeroVelas.ToString();

        numeroLibrosUI.enabled = true;
        numeroVelasUI.enabled = false;

        libro.enabled = true;
        vela.enabled = false;


    }

    void Update()
    {
        Debug.DrawRay(cameraMain.position, cameraMain.forward * rayDistance, Color.turquoise);

        RaycastHit hit;

        if (Physics.Raycast(cameraMain.position, cameraMain.forward, out hit, rayDistance, LayerMask.GetMask("Libros")))
        {
            numeroLibros += 1;
            Destroy(hit.collider.gameObject);

            if (numeroLibros >= 4)
            {
                libro.color = colorAro;
            }

        }

    }
}
