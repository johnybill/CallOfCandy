﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour{
    public float speed;
    // Update is called once per frame
    void Update(){
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other){
        Reactive_target_player player = other.GetComponent<Reactive_target_player>();
        if(player != null){
            player.ReactoHit(0.4);

        }
        Destroy(this.gameObject);
    }
}
