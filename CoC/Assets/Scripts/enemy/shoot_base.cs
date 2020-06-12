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
        while (true)
        {
            if (Vector3.Distance(Player.position, transform.position) < 1.5){
                transform.LookAt(Player.position);
                _animator.SetBool("close", true);
                whoosh.Play();
                yield return new WaitForSeconds(1f);
                if (Vector3.Distance(Player.position, transform.position) < 1)
                {
                    Reactive_target_player RTP = Player.GetComponent<Reactive_target_player>();
                    RTP.ReactoHit();
                }
                yield return new WaitForSeconds(1f);
                _animator.SetBool("close", false);
            }
            yield return new WaitForSeconds(0.5f);
        }  
    }
}
