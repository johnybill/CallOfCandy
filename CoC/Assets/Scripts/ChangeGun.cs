using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeGun : MonoBehaviour
{
    // Start is called before the first frame update
    private bool Change=false;
    private int tmp=0;
    private Renderer rend;
    private Color[] _uiColors = new Color[3];
    [SerializeField] Image[] _uiImages = new Image[3];
    private int num=0;

    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        rend.material.color = Color.red;
    }

    private void Awake() {
        int i;
        for(i = 0; i < 3; i++){
            _uiColors[i] = _uiImages[i].color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Change){
            if(tmp<14){
                transform.Rotate(-10,0,0);
                tmp++;
            }else if(tmp<28){
                if(tmp==14)ChangerArme();
                transform.Rotate(10,0,0);
                tmp++;
            }else{
                Change=false;
                tmp=0;
            }
        } else if(Input.GetKeyDown(KeyCode.R)){ //Change gun
            Change=true;
            num = (num + 1) % 3;
            

        }
    }
    void ChangerArme(){
            Color tmp = ChangeColor();
            rend.material.color = tmp;
    }
    Color ChangeColor(){
        int i;
        for(i = 0; i < 3; i++){
            _uiColors[i] = _uiImages[i].color;
        }

        var tmpColor = _uiColors[(num - 1 + 3) % 3];
        tmpColor.a = 0.5f;
        _uiColors[(num - 1 + 3) % 3] = tmpColor;
        var tmpColor2 = _uiColors[num];
        tmpColor2.a = 1;
        _uiColors[num] = tmpColor2;

        _uiImages[(num - 1 + 3) % 3].color = tmpColor;
        _uiImages[num].color = tmpColor2;
        return tmpColor2;

    }

}
