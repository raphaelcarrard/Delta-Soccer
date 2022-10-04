using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public int moedas;

    /*public io.newgrounds.core ngio_core;

    // call this method whenever you want to unlock a medal.
    void unlockMedal(int medal_id) {
        io.newgrounds.components.Medal.unlock medal_unlock = new io.newgrounds.components.Medal.unlock();
        medal_unlock.id = medal_id;
        medal_unlock.callWith(ngio_core, onMedalUnlocked);
    }

    // this will get called whenever a medal gets unlocked via unlockMedal()
    void onMedalUnlocked(io.newgrounds.results.Medal.unlock result) {
        io.newgrounds.objects.medal medal = result.medal;
        Debug.Log( "Medal Unlocked: " + medal.name + " (" + medal.value + " points)" );
    }*/

    void Awake()
    {
            instance = this;
    }

    /*void Start(){
        if(moedas >= 150){
            unlockMedal(70862);
        }
        if(moedas >= 300){
            unlockMedal(70863);
        }
        if(moedas >= 450){
            unlockMedal(70864);
        }
        if(moedas >= 600){
            unlockMedal(70865);
        }
    }*/

    public void GameStartScoreM()
    {
        if (PlayerPrefs.HasKey("moedasSave"))
        {
            moedas = PlayerPrefs.GetInt("moedasSave");
        }
        else
        {
            moedas = 100;
            PlayerPrefs.SetInt("moedasSave", moedas);
        }
    }

    public void UpdateScore()
    {
        moedas = PlayerPrefs.GetInt("moedasSave");
    }

    public void ColetaMoedas(int coin)
    {
        moedas += coin;
        SalvaMoedas(moedas);
    }

    public void PerdeMoedas(int coin)
    {
        moedas -= coin;
        SalvaMoedas(moedas);
    }

    public void SalvaMoedas(int coin)
    {
        PlayerPrefs.SetInt("moedasSave",coin);
    }

}
