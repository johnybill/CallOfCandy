using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reactive_target_player : MonoBehaviour{
    // Start is called before the first frame update
    [SerializeField] private int life; 
    private int MAXLIFE = 5;
    private bool invisible = false;
    private float time_invinsible = 5;
    private float next_time_invinsible = 0;
    [SerializeField] Image[] _imagesLife;

    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReactoHit(){
        print("touch");
        if (Time.time > next_time_invinsible){
            for (int i = 0; i < MAXLIFE; i++){
                if (_imagesLife[i].enabled == false){
                    if (i >= 1) _imagesLife[i - 1].enabled = false;
                    if (i == 1) print("I'm Dead !!!!!!");
                    break;
                }
            }
            next_time_invinsible = Time.time + time_invinsible;
        }
        
        /*
        life--;
        if(life >= 0) UILife[life].enabled = false;
        if (life == 0){
            print("I'm DEAD !!!!!!!!!!!!!!");
        }*/
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}
