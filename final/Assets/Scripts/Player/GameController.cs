using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject ui;
    
    // Start is called before the first frame update
    void Start()
    {
        ui.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
