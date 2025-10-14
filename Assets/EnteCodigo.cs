using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Video;

public class EnteCodigo : MonoBehaviour
{


    //BEGIN C#    
    //VARIABLES
    public Transform originEnte;
    public Transform entePrimero;
    public Transform enteSegundo;
    public Transform enteTercero;

    private int currentStage = 0; // 0 = origin, 1 = primero, 2 = segundo, 3 = tercero
    private Transform currentTarget;

    public Transform lookingCameraTransform;
    public Camera mainCamera;

    private UtilidadDeEspejo espejo;

    private int capa;

    [Range(0f, 1f)]
    public float sensitivity = 0.4f;
    Vector3 forwardVectorTowardsCamera;
    bool cameraLooking;
    float dotProductResult;


    private void Start()
    {
        espejo = GameObject.Find("Player").GetComponent<UtilidadDeEspejo>();
        capa = LayerMask.NameToLayer("Ente");

        originEnte.gameObject.SetActive(false);
        entePrimero.gameObject.SetActive(false);
        enteSegundo.gameObject.SetActive(false);
        enteTercero.gameObject.SetActive(false);


    }

    void Update()
    {
        //EXECUTE THE NEXT FUNCTION INSIDE UPDATE
        CheckIfCameraIsLooking();

    }

    //FUNCTIONS
    public void CheckIfCameraIsLooking()
    {

        forwardVectorTowardsCamera = (lookingCameraTransform.position - originEnte.position).normalized;
        dotProductResult = Vector3.Dot(lookingCameraTransform.forward, forwardVectorTowardsCamera);
        if (cameraLooking)
        {
            if (dotProductResult > sensitivity)
            {
                cameraLooking = false;
                StartNotLooking();

            }
        }
        else
        {
            if (dotProductResult < -sensitivity)
            {
                cameraLooking = true;
                StartLooking();
            }
        }
        if (cameraLooking)
        {
            PlayerIsLooking();
        }
        else
        {
            PlayerIsNotLooking();

        }
    }

    void StartLooking()
    {
        if (espejo.usoEspejo == true)
        {
            mainCamera.cullingMask |= 1 << capa;
            originEnte.gameObject.SetActive(false);
        }


    }
    void PlayerIsLooking()
    {
        Debug.Log("Camera is currently looking");

    }

    void StartNotLooking()
    {
        mainCamera.cullingMask &= ~(1 << capa);
    }

    void PlayerIsNotLooking()
    {
        Debug.Log("Camera is currently not looking");
    }
}

