using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int goldsOnStart;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController.Golds = goldsOnStart;
        PlayerController.Buying = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        PlayerController.OnTile = false;
    }
}
