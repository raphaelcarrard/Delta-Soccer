using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Tempo());
    }

    IEnumerator Tempo(){
        yield return new WaitForSeconds(5);
        NGHelper.instance.unlockMedal(77610);
        SceneManager.LoadScene("Menu");
    }
}
