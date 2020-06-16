using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*this class is used to make the candy cut disappear after 2 seconds. */
public class TheEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Die());
    }

    // Update is called once per frame
    private IEnumerator Die(){
        yield return new WaitForSeconds(2f);

        Destroy(this.gameObject);
    }
}
