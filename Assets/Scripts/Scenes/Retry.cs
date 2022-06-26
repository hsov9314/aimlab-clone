using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public TextMeshProUGUI scoreLabel;
    public TextMeshProUGUI accuracyLabel;
    public TextMeshProUGUI killPerSecondLabel;
    public TextMeshProUGUI targetLabel;
    public TextMeshProUGUI hitLabel;
    public TextMeshProUGUI missLabel;
    private void Start()
    {
        int score = PistolFire.instance.score;
        int fireCount = PistolFire.instance.fireCount;
        float time = CountDownTimer.instance.countDownTime;

        scoreLabel.text = score.ToString();
        accuracyLabel.text = System.String.Format("{0:f1}%", ((double)score / fireCount) * 100);
        killPerSecondLabel.text = System.String.Format("{0:f3}", score / time);
        targetLabel.text = (score + 1).ToString();
        hitLabel.text = score.ToString();
        missLabel.text = (fireCount - score).ToString();

    }
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
