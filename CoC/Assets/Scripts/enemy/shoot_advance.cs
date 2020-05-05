using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_advance : MonoBehaviour
{
    private Transform Player;
    private WanderingIA Ene;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Capsule").GetComponent<Transform>();
        Ene = GetComponent<WanderingIA>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Ene.InMove())
        {
            Reactive_target_player RTP = Player.GetComponent<Reactive_target_player>();
            RTP.ReactoHit();
        }
    }


}
