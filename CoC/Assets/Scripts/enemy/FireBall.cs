using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour{
    public float speed = 10.0f;
    public int damage = 1;


    // Update is called once per frame
    void Update(){
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other){
        Reactive_target_player player = other.GetComponent<Reactive_target_player>();
        if(player != null){
            player.ReactoHit();

        }
        Destroy(this.gameObject);
    }
}
