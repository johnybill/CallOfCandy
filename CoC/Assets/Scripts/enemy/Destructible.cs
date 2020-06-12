using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{

    public GameObject destructyedVersion; 
    // Start is called before the first frame update
    public void Die(){
        Instantiate(destructyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
