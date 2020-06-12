using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    private Color[] _colors = new Color[3];
    [SerializeField] Image[] _images = new Image[3];
    [SerializeField] Image[] _imagesLife = new Image[5];
    [SerializeField] GameObject _gun;
    [SerializeField] TextMeshProUGUI textScore;
    private int MAXLIFE = 5;
    private int _score = 0;
    private int _life = 3;
    private void Awake() {
        int i;
        for(i = 0; i < 3; i++){
            _colors[i] = _images[i].color;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent <Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if(target != null) {
                    int i;
                    for(i = 0; i < 3; i++){
                        _colors[i] = _images[i].color;
                    }
                    Color color = FindColor();
                    _score += target.ReactToHit(color);
                    textScore.text = "Score : " + _score;
                } else {
                    Color color = FindColor();
                    StartCoroutine(SphereIndicator(hit.point, color));

                }
            }
        }
        if(Input.GetKeyDown(KeyCode.E)){//Pick an upgrade
            Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                GameObject hitObject = hit.transform.gameObject;
                PickObject target = hitObject.GetComponent<PickObject>();
                if(target != null){
                    if(target.name.StartsWith("BonusMushroom")){//Add 1 life
                        AddLife();
                        target.ReactToHit();
                    }
                    else{//Add color to gun
                        Debug.Log(Vector3.Distance(hit.point, transform.position));
                        if(Vector3.Distance(hit.point, transform.position) < 2){
                            AddColorToGun(target.ReactToHit());
                        }
                    }
                }
            }
        }
    }
    private void AddLife(){
        for(int i = 0; i < MAXLIFE; i++){
            if(_imagesLife[i].enabled == false){
                _imagesLife[i].enabled = true;
                break;
            }
        }
        /*
        if(_life < 5){
            Debug.Log("test2");
            _imagesLife[_life].enabled = true;
            _life++;
        }*/
    }
    private Color FindColor() {
        if(_colors[0].a == 1) return _colors[0];
        if(_colors[1].a == 1) return _colors[1];
        return _colors[2];
    }
    private int IFindColor() {
        if(_colors[0].a == 1) return 0;
        if(_colors[1].a == 1) return 1;
        return 2;
    }

    private void AddColorToGun(Color color){
        int i;
        for(i = 0; i < 3; i++){
            _colors[i] = _images[i].color;
        }
        Color tmp = _colors[IFindColor()];
        float r = tmp.r, g = tmp.g, b = tmp.b;
        if(color.r == 1) r = 1;
        if(color.g == 1) g = 1;
        if(color.b == 1) b = 1;
        Debug.Log(new Color(r,g,b,1.0f));
        _images[IFindColor()].color = new Color(r, g, b, 1.0f);
        _gun.GetComponent<Renderer>().material.color = new Color(r, g, b, 1.0f);
    }


    private IEnumerator SphereIndicator(Vector3 pos, Color color){
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        sphere.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
        Renderer rend = sphere.GetComponent<Renderer>();
        rend.material.color = color;
        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }

    
}
