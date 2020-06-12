using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rafal_shoot : MonoBehaviour{
    private Transform Player;
    private WanderingIA Ene;
    [SerializeField] GameObject fireballPrefab;
    private GameObject[] _fireball;
    public int Limit_Fire;
    public float time_shoot;
    private float wait_shoot = 0;
    public AudioSource blaster;
    RaycastHit hit;
    // Start is called before the first frame update

    void Start(){
        Player = GameObject.Find("Capsule").GetComponent<Transform>();
        Ene = GetComponent<WanderingIA>();
        _fireball = new GameObject[Limit_Fire];
    }

    // Update is called once per frame
    void Update(){
        if (!Ene.InMove()){
            transform.LookAt(Player.position);
            if (Time.time > wait_shoot){
                wait_shoot = Time.time + time_shoot;
                for(int i = 0;  i < Limit_Fire ; i++){
                    if(_fireball[i] == null){
                        blaster.Play();
                        _fireball[i] = Instantiate(fireballPrefab) as GameObject;
                        _fireball[i].transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball[i].transform.rotation = transform.rotation;
                        break;
                    }
                }
            } 
        }
    }
}
