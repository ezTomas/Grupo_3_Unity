using UnityEngine;

public class Input_Candado : MonoBehaviour
{
    public Canvas GameObject;
    private string input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            GameObject.enabled = false;
        }

    }


    public void leerinput(string t)
    {
        input = t;
        Debug.Log(input);
    }
}

