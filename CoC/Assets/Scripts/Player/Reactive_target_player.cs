using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * this class serves as Manager Player 
 * and ReactiveTarget for the main player 
 * all the actions in contact with the player can be found here, 
 * as well as the management of his life 
 * and the display of his life on HUD
 
     */

public class Reactive_target_player : MonoBehaviour{

    [SerializeField] private int _Life = 4;
    private int MAXLIFE = 4;
    private bool invisible = false;
    private int LimitMaxLife = 10;
    private float time_invinsible = 5;
    private float next_time_invinsible = 0;
    [SerializeField] Image[] _imagesLife;


    public void ReactoHit(){
        /* action called for when an enemy hits the player in close combat or by a bullet shot.
        *
        * after having been hit and having lost a life, 
        * the player has an invincibility time which in this case is set to 5 seconds by the variable time_invinsible
         */
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
        /* increases the maximum life by 1 up to the limit defined by the variable LimitMaxLife, 
         * increases by 1 the life if it is not at maximum
         */
        if (MAXLIFE < LimitMaxLife) {
            _imagesLife[_Life].enabled = true;
            _Life++;
            MAXLIFE++;
        }
        else{
            if (_Life < MAXLIFE){
                _imagesLife[_Life].enabled = true;
                _Life++;
            }
        }
    }


    public void Invisibility(float time_seconde){
        /*add an invincibility time of time_seconds*/
        next_time_invinsible = Time.time + time_seconde;
    }


    public void Heal(){
        /* action that puts the player's life to the max as well as the one displayed on the HUD
         */
        _Life = MAXLIFE;
        for (int i = 0; i < MAXLIFE; i++){
            _imagesLife[i].enabled = true;
        }
    }
}
