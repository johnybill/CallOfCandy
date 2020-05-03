using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickObject : MonoBehaviour
{
    private Renderer rend;
    
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        //Debug.Log(rend.material.color);
    }
    public Color ReactToHit(){
        Destroy(this.gameObject);
        return rend.material.color;
    }
}
