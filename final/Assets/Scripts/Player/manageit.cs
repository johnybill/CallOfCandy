using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageit : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] private GameObject[] ItemPrefab;
    private double[] ProbabilityItems = new double[] { 0.27, 0.54, 0.85, 1 };
    private System.Random Rand = new System.Random();
    private int LimitItem = 5;


    public void FabriItem(Vector3 pos, Quaternion rot){
        pos.y = 1.05f;
        Instantiate(ItemPrefab[FindIdndexItem()], pos, rot);
    }

    private int FindIdndexItem(){
        int IndexItem;
        double proba = Rand.NextDouble();
        for (IndexItem = 0; IndexItem < LimitItem; IndexItem++){
            if (ProbabilityItems[IndexItem] > proba)
            {
                return IndexItem;
            }
        }
        Debug.Log("FindIndexNotFound");
        return 0;
    } 
}
