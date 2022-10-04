using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    [SerializeField]
    private Text pontosUI,bolasUI;
    [SerializeField]
    private GameObject losePainel,winPainel,pausePainel;
    [SerializeField]
    private Button pauseBtn,pauseBtn_Return;
    [SerializeField]
    private Button btnNovamenteLose, btnLevelLose; //Botões de Lose
    private Button btnLevelWin, btnNovamenteWin, btnAvancaWin; //Botões de Win
    private Button btnLevelPause, btnNovamentePause; //Botões de Pause

    public int moedasNumAntes, moedasNumDepois, resultado;

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
        PegaDados();
    }

    void Carrega(Scene cena, LoadSceneMode modo)
    {
        PegaDados();
    }

    void PegaDados()
    {
        if (OndeEstou.instance.fase != 1 && OndeEstou.instance.fase != 2 && OndeEstou.instance.fase != 3)
        {
            //Elementos da UI pontos e bolas
            pontosUI = GameObject.Find("PontosUI").GetComponent<Text>();
            bolasUI = GameObject.Find("BolasUI").GetComponent<Text>();
            //Paineis
            losePainel = GameObject.Find("LosePainel");
            winPainel = GameObject.Find("WinPainel");
            pausePainel = GameObject.Find("PausePainel");
            //Botões do evento Pause
            pauseBtn = GameObject.Find("pause").GetComponent<Button>();
            pauseBtn_Return = GameObject.Find("Pause").GetComponent<Button>();
            btnNovamentePause = GameObject.Find("NovamentePause").GetComponent<Button>();
            btnLevelPause = GameObject.Find("MenuFasesP").GetComponent<Button>();
            //Botões de Lose
            btnNovamenteLose = GameObject.Find("NovamenteLose").GetComponent<Button>();
            btnLevelLose = GameObject.Find("MenuFasesL").GetComponent<Button>();
            //Botões de Win
            btnLevelWin = GameObject.Find("MenuFasesW").GetComponent<Button>();
            btnNovamenteWin = GameObject.Find("NovamenteWin").GetComponent<Button>();
            btnAvancaWin = GameObject.Find("Avancar").GetComponent<Button>();
            //Eventos
            //Eventos Pause
            pauseBtn.onClick.AddListener(Pause);
            pauseBtn_Return.onClick.AddListener(PauseReturn);
            btnNovamentePause.onClick.AddListener(JogarNovamentePause);
            btnLevelPause.onClick.AddListener(LevelsPause);

            //Eventos do You Lose
            btnNovamenteLose.onClick.AddListener(JogarNovamente);
            btnLevelLose.onClick.AddListener(Levels);

            //Eventos do You Win
            btnLevelWin.onClick.AddListener(Levels);
            btnNovamenteWin.onClick.AddListener(JogarNovamente);
            btnAvancaWin.onClick.AddListener(ProximaFase);

            moedasNumAntes = PlayerPrefs.GetInt("moedasSave");

        }
    }

    public void StartUI()
    {
        LigaDesligaPainel();
    }

    public void UpdateUI()
    {
        pontosUI.text = ScoreManager.instance.moedas.ToString();
        bolasUI.text = GameManager.instance.bolasNum.ToString();
        moedasNumDepois = ScoreManager.instance.moedas;
    }

    public void GameOverUI()
    {
        losePainel.SetActive(true);
    }

    public void WinGameUI()
    {
        winPainel.SetActive(true);
    }

    void LigaDesligaPainel()
    {
        StartCoroutine(tempo());
    }

    void Pause()
    {
        pausePainel.SetActive(true);
        pausePainel.GetComponent<Animator>().Play("MoveUI_Pause");
        Time.timeScale = 0;
    }

    void PauseReturn()
    {
        pausePainel.GetComponent<Animator>().Play("MoveUI_PauseR");
        Time.timeScale = 1;
        StartCoroutine(EsperaPause());
    }

    IEnumerator EsperaPause()
    {
        yield return new WaitForSeconds(0.8f);
        pausePainel.SetActive(false);
    }

    IEnumerator tempo()
    {
        yield return new WaitForSeconds(0);
        losePainel.SetActive(false);
        winPainel.SetActive(false);
        pausePainel.SetActive(false);
    }

    void JogarNovamente()
    {
        if (GameManager.instance.win == false) {
            SceneManager.LoadScene(OndeEstou.instance.fase);
        }
            else if(GameManager.instance.win == false)
        {
            SceneManager.LoadScene(OndeEstou.instance.fase);
            resultado = moedasNumDepois - moedasNumAntes;
            ScoreManager.instance.PerdeMoedas(resultado);
            resultado = 0;
        }
        else 
        {
            SceneManager.LoadScene(OndeEstou.instance.fase);
            resultado = 0;
        }
    }

    void JogarNovamentePause()
    {
        if (GameManager.instance.win == false)
        {
            SceneManager.LoadScene(OndeEstou.instance.fase);
            resultado = moedasNumDepois - moedasNumAntes;
            ScoreManager.instance.PerdeMoedas(resultado);
            resultado = 0;
            Time.timeScale = 1;
        }
        else
        {
            SceneManager.LoadScene(OndeEstou.instance.fase);
            resultado = 0;
        }
    }

    void Levels()
    {
        if (GameManager.instance.win == false)
        {
            SceneManager.LoadScene(2);
        }
        else if (GameManager.instance.win == false) {
            resultado = moedasNumDepois - moedasNumAntes;
            ScoreManager.instance.PerdeMoedas(resultado);
            resultado = 0;
            SceneManager.LoadScene(2);
        }
        else
        {
            resultado = 0;
            SceneManager.LoadScene(2);
        }
    }

    void LevelsPause()
    {
        if (GameManager.instance.win == false)
        {
            resultado = moedasNumDepois - moedasNumAntes;
            ScoreManager.instance.PerdeMoedas(resultado);
            resultado = 0;
            SceneManager.LoadScene(2);
            Time.timeScale = 1;
        }
        else
        {
            resultado = 0;
            SceneManager.LoadScene(2);
            Time.timeScale = 1;
        }
    }

    void ProximaFase()
    {
        if (GameManager.instance.win == true)
        {
            int temp = OndeEstou.instance.fase + 1;
            SceneManager.LoadScene(temp);
        }
    }
}
