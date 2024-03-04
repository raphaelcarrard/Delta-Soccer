using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loja : MonoBehaviour
{

    public void LojaGo()
    {
        NGHelper.instance.unlockMedal(77613);
        SceneManager.LoadScene(3);
    }
}
