using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactive_target_player : MonoBehaviour{
    // Start is called before the first frame update
    [SerializeField] private int life; 

    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReactoHit(){
        life--;
        if (life == 0){
            print("I'm DEAD !!!!!!!!!!!!!!");
        }
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}
