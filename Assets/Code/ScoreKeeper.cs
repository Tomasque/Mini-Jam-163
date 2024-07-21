using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pinkScore;
    [SerializeField] TextMeshProUGUI whiteScore;
    int score = -1;

    private void Awake()
    {
        Ref.scoreKeeper = this;
    }

    public void Increment()
    {
        score++;
        pinkScore.text = score.ToString();
        whiteScore.text = score.ToString();
    }
}
