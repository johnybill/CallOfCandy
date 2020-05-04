using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour{
    private bool _alive;
    public float speed = 4.0f;
    public float obstacleRange = 5.0f;

    // Start is called before the first frame update
    void Start(){
        _alive = true;
    }

    public void setAlive(bool alive){
        _alive = alive;
    }
    // Update is called once per frame
    void Update(){
        move();
    }

    private void move(){
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

}
