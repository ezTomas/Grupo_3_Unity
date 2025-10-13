using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Image rellenoBarra;
    private Movimiento player;
    private float staminaMaxima;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Movimiento>();
        staminaMaxima = player.stamina;
    }

    // Update is called once per frame
    void Update()
    {
        rellenoBarra.fillAmount = player.stamina / staminaMaxima;
    }
}
