using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBomba : MonoBehaviour
{

    private GameObject bombaRep;

    // Start is called before the first frame update
    void Start()
    {

        bombaRep = GameObject.Find("BombaR");

    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(Vida());

    }

    IEnumerator Vida()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(bombaRep.gameObject);
        Destroy(this.gameObject);
    }

}
