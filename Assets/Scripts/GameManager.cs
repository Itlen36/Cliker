using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _textScore;
    [SerializeField] private Text _textLives;
    [SerializeField] private Text _textCountFrost;
    [SerializeField] private Text _textCountDestroyer;
    [SerializeField] private Text _textPreview;
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _panelAboutTheGame;
    [SerializeField] private GameObject _FrostPanel;
    [SerializeField] private GameObject _panelPreview;
    [SerializeField] private Button _StartGame;
    [SerializeField] private Button _btnAboutTheGame;
    [SerializeField] private Button _btnMenu;
    [SerializeField] private Text _textRecord;
    public int Score, Lives, CountFrost, CountDestroyer, record;
    public float timeStart, timeFrosr;
    public bool play = true, isFrost = false;
    void Start()
    {
        _panel.SetActive(false);
        _FrostPanel.SetActive(false);
        _panelAboutTheGame.SetActive(false);
        _panelPreview.SetActive(true);
        timeStart = Time.time;
        Score = CountFrost = CountDestroyer = 0;
        Lives = 3;
        if (PlayerPrefs.HasKey("Rrecord"))
            _textRecord.text = "Record: " + PlayerPrefs.GetInt("Record");
        else
        {
            PlayerPrefs.SetInt("Record", 0);
            _textRecord.text = "Record: 0";
        }
    }

    void StartGame()
    {
        _panel.SetActive(false);
        _FrostPanel.SetActive(false);
        _textCountDestroyer.text = "0";
        _textCountFrost.text = "0";
        _textLives.text = "Lives: 3";
        _textScore.text = "Score: 0";
        Clik[] allObj = GameObject.FindObjectsOfType<Clik>();
        foreach (Clik Obj in allObj)
            Destroy(Obj.gameObject);
        timeStart = Time.time;
        Score = CountFrost = CountDestroyer = 0;
        Lives = 3;
        play = true;
    }
    void BackToMenu()
    {
        _panel.SetActive(true);
        _panelAboutTheGame.SetActive(false);
    }
    void AboutTheGame()
    {
        _panel.SetActive(false);
        _panelAboutTheGame.SetActive(true);
    }

    void Update()
    {
        if (Time.time < 4)
            _textPreview.color = new Vector4(1f, 1f, 1f, Time.time / 4f);
        else if(Time.time> 5 && !play)
        {
            _panelPreview.SetActive(false);
            _panel.SetActive(true);
        }
        _StartGame.onClick.AddListener(delegate () { StartGame(); });
        _btnMenu.onClick.AddListener(delegate () { BackToMenu(); });
        _btnAboutTheGame.onClick.AddListener(delegate () { AboutTheGame(); });
        if (Lives == 0)
        {
            play = false;
            if (PlayerPrefs.HasKey("Record"))
                if (PlayerPrefs.GetInt("Record") < Score)
                    PlayerPrefs.SetInt("Record", Score);
                else
                    record = PlayerPrefs.GetInt("Record");
            PlayerPrefs.Save();
            _textRecord.text = "Rrecord: " + record.ToString();
            _panel.SetActive(true);
        }
        if (isFrost)
        {
            _FrostPanel.SetActive(true); ;
            if (Time.time - timeFrosr > 10)
            {
                Clik[] allObj = GameObject.FindObjectsOfType<Clik>();
                foreach (Clik Obj in allObj)
                    Obj.GetComponent<Rigidbody>().drag = 4.4f - Mathf.Pow(Time.time - timeStart, 0.25f);
                _FrostPanel.SetActive(false);
                isFrost = false;
            }
        }
       // _textScore.text = string.Format("Score: " + Score);
        //_textLives.text = string.Format("Life: " + Lives);
        //_textCountFrost.text = CountFrost.ToString();
        //_textCountDestroyer.text = CountDestroyer.ToString();
    }
}
