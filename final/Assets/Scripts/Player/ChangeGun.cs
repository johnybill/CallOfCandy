using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeGun : MonoBehaviour
{
    // Start is called before the first frame update
    private bool Change=false;
    private int tmp=0;
    private Color[] _uiColors = new Color[3];
    private Color[] _baseColor = new Color[3];
    [SerializeField] Image[] _uiImages = new Image[3];
    [SerializeField] GameObject gun;
    [SerializeField] GameObject m4;
    private Color colorGun;
    
    private int num=0;

    void Start()
    {
        _baseColor[0]=new Color(1,0,0,1);
        _baseColor[1]=new Color(0,1,0,1);
        _baseColor[2]=new Color(0,0,1,1);
        gun.GetComponent<Renderer>().material.color = Color.red;
        colorGun=new Color();
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
            MoveGun();
        } else if(Input.GetKeyDown(KeyCode.R)){ //Change gun
            Change=true;
            num = (num + 1) % 3;
        }
         else if(Input.GetKeyDown(KeyCode.P)){ //SIMULATE TOUCH BY MOB
            Touch();
        }
    }


    private void ChangerArme()
    {
        Color tmp = ChangeColor();
        //Debug.Log(tmp);
        //si on a une couleur secondaire alors 
        GunToM4(tmp);
        gun.GetComponent<Renderer>().material.color = tmp;
        m4.GetComponent<Renderer>().material.color = tmp;
    }


    private Color ChangeColor()
    {
        int i;
        for (i = 0; i < 3; i++)
        {
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

    public Color CurrentColor()
    {
        return _uiImages[FindIndexColor()].color;
    }


    private int FindIndexColor() {
        int i;
        for (i = 0; i < 3; i++) {
            if (_uiImages[i].color.a == 1) return i;
        }
        return i;
    }


    public void InvisibleGun(){
        Debug.Log("start invisible");
        for (int i = 0; i < 3; i++)
        {
            _uiColors[i] = MakeNewSecondColor(4);
        }
        colorGun = MakeNewSecondColor(4);
        ChangeColor();
        Change = true;
        Debug.Log("endChangeColor");
        for (int i = 0; i < 3; i++)
        {
            _uiColors[i] = MakeNewSecondColor(i);
        }
        MoveGun();
        Debug.Log("endInvisible");
    }


    private void GunToM4(Color color)
    {
        if (SecondaryColor(color))
        {
            gun.SetActive(false);
            m4.SetActive(true);
        }
        else
        {
            gun.SetActive(true);
            m4.SetActive(false);
        }
        gun.GetComponent<Renderer>().material.color = color;
        m4.GetComponent<Renderer>().material.color = color;
        int i = FindIndexColor();
        _uiImages[i].color = color;
    }


    private Color MakeNewSecondColor(int index){
        Color SecondColor;
        switch (index){
            case 0:
                SecondColor = new Color(1, 1, 0, 1);
                break;
            case 1:
                SecondColor = new Color(0, 1, 1, 1);
                break;
            case 2:
                SecondColor = new Color(1, 0, 1, 1);
                break;
            default:
                SecondColor = new Color(1, 1, 1, 1);
                break;
        }
        return SecondColor;
    }


    public void MoveGun()
    {
        if (tmp < 14)
        {
            m4.transform.Rotate(0, 0, 10);
            gun.transform.Rotate(-10, 0, 0);
            tmp++;
        }
        else if (tmp < 28)
        {
            if (tmp == 14)
            {
                if (colorGun.a == 0) ChangerArme();
                else
                {
                    GunToM4(colorGun);
                }
            }
            m4.transform.Rotate(0, 0, -10);
            gun.transform.Rotate(10, 0, 0);
            tmp++;
        }
        else
        {
            Change = false;
            tmp = 0;
            colorGun = new Color();
        }
    }


    public bool SecondaryColor (Color color){
        int nbColor = 0;
        if(color.r == 1)nbColor += 1;
        if(color.g == 1)nbColor += 1;
        if(color.b == 1)nbColor += 1;
        if(nbColor>1)return true;
        return false;
    }


    public void SetColorGun()
    {
        int Index = FindIndexColor();
        colorGun = MakeNewSecondColor(Index);
        Change = true;
    }


    public void Touch()
    {
        Color color = new Color();
        int i = FindIndexColor();
        color = _uiImages[i].color;
        if (SecondaryColor(color))
        {
            colorGun = _baseColor[i];
            Change = true;
        }
    }
}
