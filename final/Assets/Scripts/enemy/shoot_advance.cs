using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_advance : MonoBehaviour
{
    private Transform Player;
    private WanderingIA Ene;
    [SerializeField] GameObject fireballPrefab;
    private GameObject _fireball;
    private RaycastHit hit;
    public AudioSource blaster;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Capsule").GetComponent<Transform>();
        Ene = GetComponent<WanderingIA>();
    }

    // Update is called once per frame
    void Update(){
        if (!Ene.InMove()){
            transform.LookAt(Player.position);
            if(_fireball == null){
                blaster.Play();
                _fireball = Instantiate(fireballPrefab) as GameObject;
                _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.1f);
                _fireball.transform.rotation = transform.rotation;
            }
        }
    }


}
