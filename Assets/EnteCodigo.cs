using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Video;

public class EnteCodigo : MonoBehaviour
{


    //BEGIN C#    
    //VARIABLES
    public Transform originObject;
    public Transform lookingCameraTransform;
    public Camera mainCamera;
    
    [Range(0f, 1f)]
    public float sensitivity = 0.4f;
    Vector3 forwardVectorTowardsCamera;
    bool cameraLooking;
    float dotProductResult;


    private void Start()
    {

    }

    void Update()
    {
        //EXECUTE THE NEXT FUNCTION INSIDE UPDATE
        CheckIfCameraIsLooking();

    }

    //FUNCTIONS
    public void CheckIfCameraIsLooking()
    {

        forwardVectorTowardsCamera = (lookingCameraTransform.position - originObject.position).normalized;
        dotProductResult = Vector3.Dot(lookingCameraTransform.forward, forwardVectorTowardsCamera);
        if (cameraLooking)
        {
            if (dotProductResult > sensitivity)
            {
                cameraLooking = false;
     //           StartNotLooking();

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
    //    if (cameraLooking)
    //    {
    //        PlayerIsLooking();
    //    }
    //    else
    //    {
    //            PlayerIsNotLooking();

    //    }
    }

    void StartLooking()
    {
        int capa = LayerMask.NameToLayer("Ente");
        mainCamera.cullingMask |= 1 << capa;

    }
   // void PlayerIsLooking()
   //{
   //     Debug.Log("Camera is currently looking");

   // }

   // void StartNotLooking()
   // {
   //     Debug.Log("Camera stops looking");
   // }

   // void PlayerIsNotLooking()
   // {
   //     Debug.Log("Camera is currently not looking");
   // }
    //C# ENDS


}
