using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private double ProbaItem;
    private System.Random Rand = new System.Random();
    private manageit Man;
    public GameObject destructyedVersion; 
    // Start is called before the first frame update
    public void Die(){
        if (Rand.NextDouble() <= ProbaItem){

        }
        Instantiate(destructyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
