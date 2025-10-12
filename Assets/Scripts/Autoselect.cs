using TMPro;
using UnityEngine;


public class Autoselect : MonoBehaviour
{

    public TMP_InputField focustexto;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        focustexto.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        if(!focustexto.isFocused)
        {
            if(Input.anyKeyDown)
            {
                focustexto.ActivateInputField();
            }
        }
    }
}
