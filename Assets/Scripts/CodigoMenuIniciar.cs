using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CodigoMenuIniciar : MonoBehaviour
{

    private Animator barraAnim;
    private bool sobe;
    private string[] secretCode;
    private int index;

    void Start(){
        secretCode = new string[] { "z", "o", "n", "e", "t", "a", "n" };
        index = 0;
    }

    void Update(){
        if(Input.anyKeyDown){
            if(Input.GetKeyDown(secretCode[index])){
                index++;
            }
            else
            {
                index = 0;
            }
        }

        if(index == secretCode.Length){
            NGHelper.instance.unlockMedal(77611);
            SceneManager.LoadScene(22);
        }
    }

    public void Jogar()
    {
            NGHelper.instance.unlockMedal(70841);
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
