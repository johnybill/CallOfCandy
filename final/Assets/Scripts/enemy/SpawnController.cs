using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Random;

/*this class is used to manage the spawning of candys on the map.
 * 
 * 
 * 
 */

public class SpawnController : MonoBehaviour{
    /*table of possible prefab candy*/
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] Image[] _imageWaves;
    /*table of candy spwan on the map*/
    private GameObject[] _enemies;
    /*Queue of candy waiting to spawn on the map.*/
    private Queue<int> enemyWait;
    /*limit of candy that can go on the map.*/
    public int LimitEnemy = 15;
    /*the number of the wave*/
    public int WaveNumber = 0;
    /*time indicator between 2 spawn*/
    public float spawnWait;
    private int[] bornDown = new int[] { 0, 4, 8, 12, 15, 17 };
    private int[] bornUp = new int[] { 4, 8, 12, 15, 17, 18 };
    /*time next spawn*/
    public float spawntag;
    /*table of possible positions to spawn the candys.*/
    private Vector3[] Pos;
    /*class that allows to build the list of candys of a wave.*/
    private Number_wave nw;
    System.Random aleatoire = new System.Random();
    /*bool to know when it's the end of the wave to start the next one.  */
    [SerializeField] private bool Endwave = false;



    void Start(){
        nw = GetComponent<Number_wave>();
        VectorPos();
        enemyWait = new Queue<int>();
        _enemies = new GameObject[LimitEnemy];
        CreateWave();
    }


    void Update() {
        if (Time.time > spawnWait) {
            spawnWait = Time.time + spawntag;
            if (!Endwave){
                Debug.Log("CreatEnemy");
                CreatEnenmy();
            }
            else{
                Debug.Log("CreatWave");
                Debug.Log("waveNumber = " + WaveNumber);
                //_imageWaves[WaveNumber].enabled=true;
                CreateWave();
                Endwave = false;
            }
        }
    }


    private void CreatEnenmy(){
        /*make spwan a candy among the candys who is waiting 
         * or else verify that all the candy are dead. */
        if (enemyWait.Count != 0){
            Debug.Log("During wave");
            DuringWave();
        }
        else{
            WaitEndwave();
            Debug.Log("WaitEndwave");
        }
    }

    
    private void WaitEndwave(){
        /*make sure there's no more candy on the map.*/
        Endwave = true;
        for (int i = 0; i < LimitEnemy & Endwave ; i++){
            if (_enemies[i] != null){
                Endwave = Endwave && false;
            }
        }
    }


    private void DuringWave(){
        /*The function makes spwan a candy if the limit is not reached. */
        bool find = true;
        int newIndex;
        for (int i = 0; i < LimitEnemy & find; i++){
            if (_enemies[i] == null){
                Debug.Log("create enemy");
                newIndex = enemyWait.Dequeue();
                _enemies[i] = Instantiate(enemyPrefab[aleatoire.Next(bornDown[newIndex], 
                    bornUp[newIndex])],
                    Pos[aleatoire.Next(0,3)], Quaternion.identity);
                
                find = false;
            }
        }
    }
        

    private void VectorPos(){
        /*form the 3 position vectors to make the candys appear.*/
        Pos = new Vector3[3];
        Pos[0] = new Vector3(-4, 2, 8);
        Pos[1] = new Vector3(4, 2, -8);
        Pos[2] = new Vector3(-4, 2, -9);
    }


    private void CreateWave() {
        enemyWait = nw.Create_wave(WaveNumber);
        WaveNumber++;
    }
}
