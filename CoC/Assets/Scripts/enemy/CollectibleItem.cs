using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Random;
public class CollectibleItem : MonoBehaviour{


    private System.Random Rand = new System.Random();
    private int NumberItem;
    private double[] ProbabilityItems = new double[] { 0.17, 0.34, 0.57, 0.85 }; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Reactive_target_player>()) {
            Destroy(this.gameObject);
        }
    }


}
