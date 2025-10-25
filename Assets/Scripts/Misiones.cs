using UnityEngine;
using TMPro;

public class Misiones : MonoBehaviour
{
    [SerializeField] private TMP_Text texto1;
    [SerializeField] private TMP_Text texto2;
    [SerializeField] private TMP_Text texto3;
    [SerializeField] private TMP_Text texto4;
    [SerializeField] private TMP_Text texto5;
    [SerializeField] private TMP_Text texto6;


    public int misione = 1;

    void Start()
    {
        texto2.enabled = false;
        texto3.enabled = false;
        texto4.enabled = false;
        texto5.enabled = false;
        texto6.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (misione == 2)
        {
            texto2.enabled = true;
            texto1.enabled = false;
        }
        if (misione == 3)
        {
            texto3.enabled = true;
            texto2.enabled = false;
        }
        if (misione == 4)
        {
            texto4.enabled = true;
            texto3.enabled = false;
        }
        if (misione == 5)
        {
            texto5.enabled = true;
            texto4.enabled = false;
        }
        if (misione == 6)
        {
            texto6.enabled = true;
            texto5.enabled = false;
        }
    }


}
