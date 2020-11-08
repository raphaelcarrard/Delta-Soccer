using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirObjetoComClique : MonoBehaviour
{
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
                Destroy(this.gameObject);
        }
    }
}