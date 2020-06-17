using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_base : MonoBehaviour{
    private Transform Player;
    private WanderingIA Ene;
    private float delai;
    private Animator _animator;
    public AudioSource whoosh;

    /*
     * this class handles the close attack of the basic candys.
     * basic candy == blue, red, green
     */

    // Start is called before the first frame update
    void Start(){
        Player = GameObject.Find("Capsule").GetComponent<Transform>();
        Ene = GetComponent<WanderingIA>();
        _animator = GetComponent<Animator>();
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update(){
        
    }
    IEnumerator Attack(){
        while (true){
            /*test the minimum distance to attack */
            if (Vector3.Distance(Player.position, transform.position) < 1.8){
                transform.LookAt(Player.position);
                /*start animation attack*/
                _animator.SetBool("close", true);
                /*start sound attack*/
                whoosh.Play();
                yield return new WaitForSeconds(1f);
                /*wait 1 second and test if the distance is enough close for touch
                 after 1 seconds the candy is in the middle of animation. */
                if (Vector3.Distance(Player.position, transform.position) < 1.4){
                    Reactive_target_player RTP = Player.GetComponent<Reactive_target_player>();
                    RTP.ReactoHit(0.2);
                }

                yield return new WaitForSeconds(1f);
                /*the animation attack is finished*/
                _animator.SetBool("close", false);
            }
            /*wait 0.5 second for the next attack*/
            yield return new WaitForSeconds(0.5f);
        }  
    }
}
