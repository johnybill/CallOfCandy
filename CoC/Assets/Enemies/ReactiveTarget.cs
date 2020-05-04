using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour{
    // Start is called before the first frame update
    public void ReactToHit(){
        WanderingAI behavoir = GetComponent<WanderingAI>();
        if(behavoir != null){
            behavoir.setAlive(false);
        }
        StartCoroutine(Die());
    }
    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
