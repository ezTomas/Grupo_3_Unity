using TMPro;
using UnityEngine;

public class CodeController : MonoBehaviour

{
    public Canvas ochoTres;
    public Canvas seisCuatro;

    public TextMeshPro numero83;
    public TextMeshPro numero64;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

       ochoTres.enabled = false;
       seisCuatro.enabled = false;

       numero64.enabled = true;
       numero83.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("83"))
        {
            ochoTres.enabled = true;
            numero83.enabled = false;
        }

        if (other.CompareTag("64"))
        {
            seisCuatro.enabled = true;
            numero64.enabled = false;
        }
    }

}
