using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Random;
public class CollectibleItem : MonoBehaviour{


    [SerializeField] private int NumberItem;
    
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Reactive_target_player>()) {
            Reactive_target_player RTP = other.GetComponent<Reactive_target_player>();
            switch (NumberItem){
                case 1:
                    Debug.Log("Heal Bonus");
                    RTP.Heal();
                    break;
                case 2:
                    Debug.Log("Add Life Bonus");
                    RTP.AddLife();
                    break;
                case 3:
                    Debug.Log("Merge Bonus");
                    break;
                case 4:
                    Debug.Log("Shield Bonus");
                    break;
                case 5:
                    Debug.Log("WhitePower Bonus");
                    break;
            }
            Destroy(this.gameObject);
        }
    }


}
