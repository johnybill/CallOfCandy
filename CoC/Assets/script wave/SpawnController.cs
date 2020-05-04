using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour{
    [SerializeField] private GameObject[] enemyPrefab;
    private GameObject[] _enemies;
    private Queue<int> enemyWait;
    public int LimitEnemy = 15;
    public int WaveNumber = 0;
    public float spawnWait = 7;
    public float spawntag = 8;
    private Vector3[] Pos;
    private Number_wave nw;
    private bool Endwave = false;


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
        for (int i = 0; i < LimitEnemy & !Endwave ; i++){
            if (_enemies[i] != null){
                break;
            }else{
                print("Endwave");
                Endwave = true; 
            }
        }
    }

    private void DuringWave(){
        bool find = true;
        for (int i = 0; i < LimitEnemy & find; i++){
            if (_enemies[i] == null){
                print("create enemy");
                _enemies[i] = Instantiate(enemyPrefab[enemyWait.Dequeue()],
                    Pos[i%3], Quaternion.identity);
                float angle = Random.Range(0, 360f);
                _enemies[i].transform.Rotate(0, angle, 0);
                find = false;
            }
        }
    }
        
    private void VectorPos(){
        Pos = new Vector3[3];
        for (int i = 0; i < 3; i++){
            Pos[i] = new Vector3(Random.Range(-20,20), 1, Random.Range(-20, 20));
        }
    }

    private void CreateWave() {
        enemyWait = nw.Create_wave(WaveNumber);
        WaveNumber++;
    }
}
