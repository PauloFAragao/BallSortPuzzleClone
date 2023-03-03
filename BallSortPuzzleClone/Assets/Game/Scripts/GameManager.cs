using UnityEngine.SceneManagement;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int level { get; private set; }

    public bool gamePause;

    public int moves = 0;

    private void Awake()
    {
        //setando fps para no maximo 60
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        if (Instance != null)
            DestroyImmediate(gameObject);

        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            if (Screen.height / Screen.width > 2.222f)//proporção de 9:20
            {
                Camera.main.aspect = 9f / 20f;
            }
            else if (Screen.height / Screen.width > 2f)//proporção de 9:18
            {
                Camera.main.aspect = 9f / 18f;
            }
            else//proporção de 9/16 -- 1.777
            {
                Camera.main.aspect = 9f / 16f;
            }
        }

        //carregando dados do jogo
        LoadData();

        //level = 0;
    }

    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

    public void LoadNextLevel()
    {
        gamePause = false;//retirando o game pause

        //level++;//incrementando o level

        //SaveData();//salvando dados

        //zerando as jogadas
        moves = 0;

        //carregar o level
        SceneManager.LoadScene("SampleScene");
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SaveLevelData()
    {
        //salvando o level
        PlayerPrefs.SetInt("level", ++level);

        Debug.Log("salvando: "+level);
    }

    private void LoadData()
    {
        //carregando o level
        level = PlayerPrefs.GetInt("level");
    }

    
}
