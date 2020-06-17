using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Image image;
    private Image image1;
    private Image image2;
    private Image image3;
    private int num=0;
    void Start()
    {
        GameObject imageObject = GameObject.Find("CouleurFusil/Couleur1");
        image1 = imageObject.GetComponent<Image>();
        image1.color = new Color(image1.color[0],image1.color[1],image1.color[2],1);
        GameObject imageObject2 = GameObject.Find("CouleurFusil/Couleur2");
        image2 = imageObject2.GetComponent<Image>();
        GameObject imageObject3 = GameObject.Find("CouleurFusil/Couleur3");
        image3 = imageObject3.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            if(num==0){
                changeCouleur(image1,image2);
            }else if(num==1){
                changeCouleur(image2,image3);
            }else{
                changeCouleur(image3,image1);
            }
            num++;
            if(num>2)num=0;
        }
    }
    void changeCouleur(Image lastI, Image newI){
        lastI.color = new Color(lastI.color[0],lastI.color[1],lastI.color[2],0.5882f);
        newI.color = new Color(newI.color[0],newI.color[1],newI.color[2],1);
    }
}
