using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    [SerializeField] List<GameObject> banners;
    [SerializeField] float onDuration;
    [SerializeField] float offDuration;
    [SerializeField] int flashCycles;
    [SerializeField] float flashDelay;

    private void Awake()
    {
        Ref.currentPlayer++;
        if(Ref.currentPlayer >= Ref.players)
        {
            Ref.currentPlayer = 0;
        }

        if(Ref.players == 2)
        {
            StartCoroutine(FlashBanner());
        }
    }

    IEnumerator FlashBanner()
    {
        int p = Ref.currentPlayer;

        yield return new WaitForSeconds(flashDelay);

        for (int i = 0; i < flashCycles; i++)
        {
            banners[p].SetActive(true);

            yield return new WaitForSeconds(onDuration);

            banners[p].SetActive(false);

            yield return new WaitForSeconds(offDuration);
        }
    }
}
