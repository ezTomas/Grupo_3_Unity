using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{

    [SerializeField] private GameObject objectThatLook;
    [SerializeField] private GameObject objectToLook;

    [SerializeField] private float yPos;

    private Vector3 objectThatLookposition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectToLook = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()

    {
         LookAtObject();   
    }

    private void LookAtObject()
    {
        objectThatLookposition = objectToLook.transform.position;

        objectThatLookposition.y = yPos; 

        objectThatLook.transform.LookAt(objectThatLookposition);
    }
}
