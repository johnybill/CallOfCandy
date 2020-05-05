using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderingIA : MonoBehaviour{
    private bool _alive;
    protected Transform Target;
    private NavMeshAgent AgentEnnemi;

    // Start is called before the first frame update
    void Start(){
        _alive = true;
        AgentEnnemi = GetComponent<NavMeshAgent>();
        if(AgentEnnemi != null)
        {
            Target = GameObject.Find("Capsule").GetComponent<Transform>();
            if (Target == null)
            {
                print("warning target is null");
            }
        }
        else
        {
            print("navMashAgent is null");
        }
    }

    public void setAlive(bool alive){
        _alive = alive;
    }
    // Update is called once per frame
    void Update(){
        move();
    }

    private void move(){
        if (_alive){
            AgentEnnemi.SetDestination(Target.position);
        }
    }

    public bool InMove(){
        return AgentEnnemi.velocity.magnitude != 0;
    }
}
