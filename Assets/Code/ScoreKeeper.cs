using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> pinkScore;
    [SerializeField] List<TextMeshProUGUI> whiteScore;
    [SerializeField] List<TextMeshProUGUI> pinkHighScore;
    [SerializeField] List<TextMeshProUGUI> whiteHighScore;
    [SerializeField] GameObject playerTwo;

    private void Awake()
    {
        Ref.scoreKeeper = this;
    }

    private void Start()
    {
        Ref.latestScore[Ref.currentPlayer] = 0;

        pinkScore[0].text = Ref.latestScore[0].ToString();
        whiteScore[0].text = Ref.latestScore[0].ToString();
        pinkHighScore[0].text = Ref.highScore[0].ToString();
        whiteHighScore[0].text = Ref.highScore[0].ToString();

        if (Ref.players == 2)
        {
            playerTwo.SetActive(true);
            pinkScore[1].text = Ref.latestScore[1].ToString();
            whiteScore[1].text = Ref.latestScore[1].ToString();
            pinkHighScore[1].text = Ref.highScore[1].ToString();
            whiteHighScore[1].text = Ref.highScore[1].ToString();
        }
    }

    public void Increment()
    {
        Ref.latestScore[Ref.currentPlayer]++;
        pinkScore[Ref.currentPlayer].text = Ref.latestScore[Ref.currentPlayer].ToString();
        whiteScore[Ref.currentPlayer].text = Ref.latestScore[Ref.currentPlayer].ToString();

        if(Ref.latestScore[Ref.currentPlayer] > Ref.highScore[Ref.currentPlayer])
        {
            Ref.highScore[Ref.currentPlayer] = Ref.latestScore[Ref.currentPlayer];
            pinkHighScore[Ref.currentPlayer].text = Ref.highScore[Ref.currentPlayer].ToString();
            whiteHighScore[Ref.currentPlayer].text = Ref.highScore[Ref.currentPlayer].ToString();
        }
    }
}
