using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reactive_target_player : MonoBehaviour{
    // Start is called before the first frame update
    [SerializeField] private int _Life = 4; 
    private int MAXLIFE = 4;
    private bool invisible = false;
    private int LimitMaxLife = 10;
    private float time_invinsible = 5;
    private float next_time_invinsible = 0;
    [SerializeField] Image[] _imagesLife;


    public void ReactoHit(){
        Debug.Log("touch");
        if (Time.time > next_time_invinsible){
            _Life--;
            if (_Life >= 0){
                if(_Life == 0){
                    Debug.Log("I'm Dead !!!!!!");
                }
                else{
                    _imagesLife[_Life].enabled = false;
                }
            }
            next_time_invinsible = Time.time + time_invinsible;
        }
    }

    public void AddLife(){
        if (MAXLIFE < LimitMaxLife) {
            _imagesLife[_Life].enabled = true;
            _Life++;
            MAXLIFE++;
        }
        else
        {
            if (_Life < MAXLIFE)
            {
                _imagesLife[_Life].enabled = true;
                _Life++;
            }
        }
        
    }

    public void Heal(){
        _Life = MAXLIFE;
        for (int i = 0; i < MAXLIFE; i++){
            _imagesLife[i].enabled = true;
        }
    }


    private IEnumerator Die(){
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}
