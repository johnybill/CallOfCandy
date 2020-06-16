using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this class applies to Bonus type objects, 
    it allows to rotate on itself the cube that composes a bonus, 
    so that the player notices it more quickly.
     */

public class TurnItem : MonoBehaviour{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up);
    }
}
