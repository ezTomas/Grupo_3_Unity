using UnityEngine;

public class Luz_Reveladora : MonoBehaviour
{
    private MeshRenderer mesh;
    private Linterna_Espejo linterna_Espejo;
    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        linterna_Espejo = GetComponentInParent<Linterna_Espejo>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pared_Destroy"))
        {
            if (linterna_Espejo.luzLinterna.enabled == true)
            {
                MeshRenderer otherMesh = other.gameObject.GetComponent<MeshRenderer>();
                if (otherMesh != null && linterna_Espejo.luzLinterna.enabled == true)
                {
                    otherMesh.enabled = false;
                }
                if (linterna_Espejo.luzLinterna.enabled == false)
                {
                    otherMesh.enabled = true;
                }
;
            }
        }      
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pared_Destroy"))
        {
            MeshRenderer otherMesh = other.gameObject.GetComponent<MeshRenderer>();
            if (otherMesh != null)
            {
                otherMesh.enabled = true;
            }
        }
    }
}
