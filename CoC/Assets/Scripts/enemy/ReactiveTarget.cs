using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactiveTarget : MonoBehaviour
{
    private Renderer rend;
    

    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        Debug.Log(rend.material.color);
    }

    public int ReactToHit(Color color) { //color = color of gun
        float r = rend.material.color.r, g = rend.material.color.g, b = rend.material.color.b;
        int score = 0;
        //we take off the colors from the gun on the candy.
        if(color.r == 1 && r == 1) {
            r=0;
            score++;
        }  
        if(color.g == 1 && g == 1) {
            g=0;
            score++;
        } 
        if(color.b == 1 && b == 1) {
            b=0;
            score++;
        }
        rend.material.color = new Color(r, g, b, 1.0f);
        if(r == g && r == b && r == 0){ //if the candy has no more color, we destroy it.
            Destructible des = GetComponent<Destructible>();
            des.Die();
        }
        return score;
    }
}
