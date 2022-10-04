using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CodigoMenuIniciar : MonoBehaviour
{

    private Animator barraAnim;
    private bool sobe;

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

    public void Jogar()
    {
            //unlockMedal(70841);
            SceneManager.LoadScene(2);
    }

    public void AnimaMenu()
    {
        barraAnim = GameObject.FindGameObjectWithTag("barraAnimTag").GetComponent<Animator>();
        if (sobe == false)
        {
            barraAnim.Play("Move_UI");
            sobe = true;
        }
        else
        {
            barraAnim.Play("Move_UI_Inverso");
            sobe = false;
        }
        
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}
