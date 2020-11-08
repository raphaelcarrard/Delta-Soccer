﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OndeEstou : MonoBehaviour
{
    
    public int fase = -1;
    [SerializeField]
    private GameObject UIManagerGO, GameManagerGO;

    public static OndeEstou instance;
    public int bolaEmUso;
    private float orthoSize = 5;
    [SerializeField]
    private float aspect = 1.75f;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += VerificaFase;

        bolaEmUso = PlayerPrefs.GetInt("BolaUse");

    }

    void VerificaFase(Scene cena, LoadSceneMode modo)
    {
        fase = SceneManager.GetActiveScene().buildIndex;
        if (fase != 0 && fase != 1 && fase != 2)
        {
            Instantiate(UIManagerGO);
            Instantiate(GameManagerGO);
            Camera.main.projectionMatrix = Matrix4x4.Ortho(-orthoSize * aspect, orthoSize * aspect, -orthoSize, orthoSize, Camera.main.nearClipPlane, Camera.main.farClipPlane);
        }
    }
}