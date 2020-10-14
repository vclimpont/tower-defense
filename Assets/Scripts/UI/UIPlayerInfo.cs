using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerInfo : MonoBehaviour
{
    public Text textGold;
    public Text textHealth;

    // Update is called once per frame
    void Update()
    {
        textGold.text = "GOLD : " + PlayerController.Gold;
        textHealth.text = "HEALTH : " + PlayerController.Health;
    }
}
