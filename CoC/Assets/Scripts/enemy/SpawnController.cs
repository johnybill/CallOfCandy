using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Random;

public class SpawnController : MonoBehaviour{
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] Image[] _imageWaves;
    private GameObject[] _enemies;
    private Queue<int> enemyWait;
    public int LimitEnemy = 15;
    public int WaveNumber = 0;
    public float spawnWait = 7;
    private int[] bornDown = new int[] { 0, 4, 8, 12, 15, 17 };
    private int[] bornUp = new int[] { 4, 8, 12, 15, 17, 18 };
    public float spawntag = 8;
    private Vector3[] Pos;
    private Number_wave nw;
    System.Random aleatoire = new System.Random();
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
                print("CreatEnemy");
                CreatEnenmy();
            }
            else{
                print("CreatWave");
                print("waveNumber = " + WaveNumber);
                //_imageWaves[WaveNumber].enabled=true;
                CreateWave();
                Endwave = false;
            }
        }
    }

    private void CreatEnenmy(){
        if (enemyWait.Count != 0){
            print("During wave");
            DuringWave();
        }
        else{
            WaitEndwave();
            print("WaitEndwave");
        }
    }

    private void WaitEndwave(){
        Endwave = true;
        for (int i = 0; i < LimitEnemy & Endwave ; i++){
            if (_enemies[i] != null){
                Endwave = Endwave && false;
            }
        }
    }

    private void DuringWave(){
        bool find = true;
        int newIndex;
        for (int i = 0; i < LimitEnemy & find; i++){
            if (_enemies[i] == null){
                print("create enemy");
                newIndex = enemyWait.Dequeue();
                _enemies[i] = Instantiate(enemyPrefab[aleatoire.Next(bornDown[newIndex], 
                    bornUp[newIndex])],
                    Pos[aleatoire.Next(0,3)], Quaternion.identity);
                
                find = false;
            }
        }
    }
        
    private void VectorPos(){
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
