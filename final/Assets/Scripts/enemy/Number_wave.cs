using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number_wave : MonoBehaviour{
    private List<List<int>> list_wave;
    private List<int> _wave0;
    private List<int> _wave1;
    private List<int> _wave2;
    private List<int> _wave3;
    private List<int> _wave4;
    private List<int> _wave5;
    private static Random rng = new Random();


    // Start is called before the first frame update
    public Number_wave(){
        _wave0 = new List<int> {0, 0, 1, 1, 0, 0, 0, 0} ;
        _wave1 = new List<int> { 1, 1, 2, 2, 2, 0, 0, 0, 0};
        _wave2 = new List<int> { 1, 2, 0, 3, 3, 0, 0, 1};
        _wave3 = new List<int> { 3, 3, 1, 4, 0, 2, 2};
        _wave4 = new List<int> { 4, 1, 5, 0 };
        _wave5 = new List<int> { 5, 1, 5 };
        list_wave = new List<List<int>> { _wave0, _wave1, _wave2, _wave3, _wave4, _wave5 };
    }

    public Queue<int> Create_wave(int number_wave){
        List<int> new_wave = new List<int> { };
        List<int> number_in_base_six = new List<int> { };
        number_in_base_six = BaseSix(number_wave);
        for(int i = 0; i < number_in_base_six.Count; i++){
            new_wave.AddRange(list_wave[number_in_base_six[i]]);
        }
        Shuffle(new_wave);
        Queue<int> queue = new Queue<int>(new_wave);
        return queue;
    }

    private List<int> BaseSix (int number){
        List<int> listBaseSix = new List<int> { };
        while (number / 6 != 0) {
            listBaseSix.Add(number % 6);
            number = number / 6;
        }
        listBaseSix.Add(number);
        listBaseSix.Reverse();
        return listBaseSix;
    }

    private static void Shuffle(List<int> list_wave){
        for (int i = 0; i < list_wave.Count; i++){
            int temp = list_wave[i];
            int randomIndex = Random.Range(i, list_wave.Count);
            list_wave[i] = list_wave[randomIndex];
            list_wave[randomIndex] = temp;
        }
    }
}
