using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public RawImage startMessagePanel;
    public TextMeshProUGUI startMessageLabel;
    public RawImage countDownTimerPanel;
    public TextMeshProUGUI countDownTimerLabel;

    public float countDownTime;
    private float _countDownTime = float.MaxValue;
    private bool _isStarted = false;

    public static CountDownTimer instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        //hide countdown timer
        countDownTimerPanel.enabled = false;
        countDownTimerLabel.enabled = false;
    }

    void Update()
    {
        if (_isStarted)
        {
            countDownTimerLabel.text = System.String.Format("{0:00.00}", _countDownTime);
            _countDownTime -= Time.deltaTime;
        }

        if (_countDownTime - Time.deltaTime < 0 && _isStarted)
        {
            _isStarted = false;
            //show result scene
            SceneManager.LoadScene("ResultScene");
        }
    }


    public void startCountDown(float time)
    {
        _isStarted = true;
        _countDownTime = time;
        countDownTime = time;

        //hide start message
        startMessagePanel.enabled = false;
        startMessageLabel.enabled = false;

        //show countdown timer
        countDownTimerPanel.enabled = true;
        countDownTimerLabel.enabled = true;

        countDownTimerLabel.text = System.String.Format("{0:00.00}", _countDownTime);
    }

    public bool isStarted()
    {
        return _isStarted;
    }
}
