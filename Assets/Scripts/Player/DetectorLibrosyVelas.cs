using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectorLibrosyVelas : MonoBehaviour
{
    private Transform cameraMain;
    public float rayDistance;

    void Start()
    {
        cameraMain = transform.Find("Main Camera");
    }

    void Update()
    {
        Debug.DrawRay(cameraMain.position, cameraMain.forward * rayDistance, Color.turquoise);

        RaycastHit hit;

    }
}
