using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    //Bola
    [SerializeField]
    public GameObject[] bola;
    public int bolasNum = 2;
    public int bolasEmCena = 0;
    public Transform pos;
    public bool win;
    public int tiro = 0;
    public bool jogoComecou;
    public bool medal1, medal2, medal3, medal4, medal5, medal6, medal7, medal8, medal9, medal10, medal11, medal12, medal13, medal14, medal15, medal16, medal17, medal18;
    public bool medalcoin1, medalcoin2, medalcoin3, medalcoin4;

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

        SceneManager.sceneLoaded += Carrega;
        pos = GameObject.Find("posStart").GetComponent<Transform>();
    }

    void Carrega(Scene cena, LoadSceneMode modo)
    {
        if (OndeEstou.instance.fase != 0 && OndeEstou.instance.fase != 1 && OndeEstou.instance.fase != 2 && OndeEstou.instance.fase != 3 && OndeEstou.instance.fase != 22) 
        {
            pos = GameObject.Find("posStart").GetComponent<Transform>();
            StartGame();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {

        ScoreManager.instance.UpdateScore();
        UIManager.instance.UpdateUI();
        NascBolas();

        if (bolasNum <= 0 && win == false)
        {
            GameOver();
        }

        if (win == true)
        {
            WinGame();
        }
        if (win == false)
        {
            NascBolas();
        }
        if(PlayerPrefs.GetInt("moedasSave") >= 150 && medalcoin1 == false){
            NGHelper.instance.unlockMedal(70862);
            medalcoin1 = true;
        }
        if(PlayerPrefs.GetInt("moedasSave") >= 300 && medalcoin2 == false){
            NGHelper.instance.unlockMedal(70863);
            medalcoin2 = true;
        }
        if(PlayerPrefs.GetInt("moedasSave") >= 450 && medalcoin3 == false){
            NGHelper.instance.unlockMedal(70864);
            medalcoin3 = true;
        }
        if(PlayerPrefs.GetInt("moedasSave") >= 600 && medalcoin4 == false){
            NGHelper.instance.unlockMedal(70865);
            medalcoin4 = true;
        }
    }

    void NascBolas()
    {
        if (OndeEstou.instance.fase >= 3)
        {
            if (bolasNum > 0 && bolasEmCena == 0 && Camera.main.transform.position.x <= 0.05f)
            {
                Instantiate(bola[OndeEstou.instance.bolaEmUso], new Vector2(pos.position.x, pos.position.y), Quaternion.identity);
                bolasEmCena += 1;
                tiro = 0;
            }
        }
        else 
        {
            if (bolasNum > 0 && bolasEmCena == 0)
            {
                Instantiate(bola[OndeEstou.instance.bolaEmUso], new Vector2(pos.position.x, pos.position.y), Quaternion.identity);
                bolasEmCena += 1;
                tiro = 0;
            }
        }
    }

    void GameOver()
    {
        UIManager.instance.GameOverUI();
        jogoComecou = false;
    }

    void WinGame()
    {
        UIManager.instance.WinGameUI();
        jogoComecou = false;
        if(OndeEstou.instance.fase == 4 && medal1 == false){
            NGHelper.instance.unlockMedal(77614);
            medal1 = true;
        }
        if(OndeEstou.instance.fase == 5 && medal2 == false){
            NGHelper.instance.unlockMedal(77615);
            medal2 = true;
        }
        if(OndeEstou.instance.fase == 6 && medal3 == false){
            NGHelper.instance.unlockMedal(77616);
            medal3 = true;
        }
        if(OndeEstou.instance.fase == 7 && medal4 == false){
            NGHelper.instance.unlockMedal(77617);
            medal4 = true;
        }
        if(OndeEstou.instance.fase == 8 && medal5 == false){
            NGHelper.instance.unlockMedal(77618);
            medal5 = true;
        }
        if(OndeEstou.instance.fase == 9 && medal6 == false){
            NGHelper.instance.unlockMedal(77619);
            medal6 = true;
        }
        if(OndeEstou.instance.fase == 10 && medal7 == false){
            NGHelper.instance.unlockMedal(77620);
            medal7 = true;
        }
        if(OndeEstou.instance.fase == 11 && medal8 == false){
            NGHelper.instance.unlockMedal(77621);
            medal8 = true;
        }
        if(OndeEstou.instance.fase == 12 && medal9 == false){
            NGHelper.instance.unlockMedal(77622);
            medal9 = true;
        }
        if(OndeEstou.instance.fase == 13 && medal10 == false){
            NGHelper.instance.unlockMedal(77623);
            medal10 = true;
        }
        if(OndeEstou.instance.fase == 14 && medal11 == false){
            NGHelper.instance.unlockMedal(77624);
            medal11 = true;
        }
        if(OndeEstou.instance.fase == 15 && medal12 == false){
            NGHelper.instance.unlockMedal(77625);
            medal12 = true;
        }
        if(OndeEstou.instance.fase == 16 && medal13 == false){
            NGHelper.instance.unlockMedal(77626);
            medal13 = true;
        }
        if(OndeEstou.instance.fase == 17 && medal14 == false){
            NGHelper.instance.unlockMedal(77627);
            medal14 = true;
        }
        if(OndeEstou.instance.fase == 18 && medal15 == false){
            NGHelper.instance.unlockMedal(77628);
            medal15 = true;
        }
        if(OndeEstou.instance.fase == 19 && medal16 == false){
            NGHelper.instance.unlockMedal(77629);
            medal16 = true;
        }
        if(OndeEstou.instance.fase == 20 && medal17 == false){
            NGHelper.instance.unlockMedal(77630);
            medal17 = true;
        }
        if(OndeEstou.instance.fase == 21 && medal18 == false){
            NGHelper.instance.unlockMedal(77631);
            medal18 = true;
        }
    }

    void StartGame()
    {
        jogoComecou = true;
        bolasNum = 2;
        bolasEmCena = 0;
        win = false;
        UIManager.instance.StartUI();
    }

}
