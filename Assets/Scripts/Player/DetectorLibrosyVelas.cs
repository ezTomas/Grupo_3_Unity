using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DetectorLibrosyVelas : MonoBehaviour
{
    private Transform cameraMain;
    public float rayDistance;
    private EnteCodigo enteCodigo;

    public TMP_Text numeroVelasUI;
    public TMP_Text numeroLibrosUI;

    public Image libro;
    public Image vela;

    private int numeroVelas = 0;
    private int numeroLibros = 0;

    public Color colorAro = Color.lightGreen;

    private Misiones misiones;

    void Start()
    {
        cameraMain = transform.Find("Main Camera");

        enteCodigo = GameObject.Find("Ente Principal").GetComponent<EnteCodigo>();

        misiones = GameObject.Find("Misiones").GetComponent<Misiones>();

        numeroLibrosUI.enabled = false;
        numeroVelasUI.enabled = false;

        libro.enabled = false;
        vela.enabled = false;


    }

    void Update()
    {
        numeroLibrosUI.text = numeroLibros.ToString();
        numeroVelasUI.text = numeroVelas.ToString();

        Debug.DrawRay(cameraMain.position, cameraMain.forward * rayDistance, Color.turquoise);

        RaycastHit hit;

        if (Physics.Raycast(cameraMain.position, cameraMain.forward, out hit, rayDistance, LayerMask.GetMask("Libros")) && libro.enabled) 
        {

            numeroLibros += 1;
            Destroy(hit.collider.gameObject);

            if (numeroLibros == 4)
            {
                libro.color = colorAro;
                numeroLibrosUI.fontMaterial.SetColor("_OutlineColor", colorAro);
            }

        }

        if (Physics.Raycast(cameraMain.position, cameraMain.forward, out hit, rayDistance, LayerMask.GetMask("Velas")) && vela.enabled)
        {

            numeroVelas += 1;
            Destroy(hit.collider.gameObject);

            if (numeroVelas == 6)
            {
                vela.color = colorAro;
                numeroVelasUI.fontMaterial.SetColor("_OutlineColor", colorAro);
            }

        }

        if (numeroLibros == 4 && numeroVelas == 6)
        {
            guardarMetricas();

            misiones.misione += 1;

        }

    }

    public void guardarMetricas()
    {
        enteCodigo.myTimer.StopTimer();
        Metricas.Instance.RegistrarEvento("Completa Puzzle", enteCodigo.myTimer.GetTime());
    }
}
