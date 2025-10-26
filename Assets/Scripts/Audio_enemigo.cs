using UnityEngine;

public class Audio_enemigo : MonoBehaviour
{

    public GameObject player; 
    public AudioSource source;
    void Start()
    {
        source.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            source.Play();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        source.Stop();
    }
}
