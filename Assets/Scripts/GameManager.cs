using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _textScore;
    [SerializeField] private Text _textLives;
    [SerializeField] private Text _textCountFrost;
    [SerializeField] private Text _textCountDestroyer;
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _FrostPanel;
    [SerializeField] private Button _StartGame;
    public int Score, Lives, CountFrost, CountDestroyer;
    public float timeStart, timeFrosr;
    public bool play = true, isFrost = false;
    void Start()
    {
        _panel.SetActive(true);
        _FrostPanel.SetActive(false);
        timeStart = Time.time;
        Score = CountFrost= CountDestroyer = 0;
        Lives = 3;
    }

    void StartGame()
    {
        _panel.SetActive(false);
        _FrostPanel.SetActive(false);
        Clik[] allObj = GameObject.FindObjectsOfType<Clik>();
        foreach (Clik Obj in allObj)
            Destroy(Obj.gameObject);
        timeStart = Time.time;
        Score = CountFrost = CountDestroyer = 0;
        Lives = 3;
        play = true;
    }
    
    void Update()
    {
        //GameObject[] ps = GameObject.FindGameObjectsWithTag("PariclSystem");
        //foreach (GameObject Obj in ps)
        //    .if(Obj.t)
        _StartGame.onClick.AddListener(delegate() { StartGame(); });
        if (Lives == 0)
        {
            play = false;
            _panel.SetActive(true); ;
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
        _textScore.text = string.Format("Score: " + Score);
        _textLives.text = string.Format("Life: " + Lives);
        _textCountFrost.text = CountFrost.ToString();
        _textCountDestroyer.text = CountDestroyer.ToString();
    }
}
