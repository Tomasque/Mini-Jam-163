using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] List<GameObject> HP;
    int currentHP;

    private void Awake()
    {
        currentHP = HP.Count;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Tags T = collision.gameObject.GetComponent<Tags>();
        if (T == null || !(T.harms || T.instantDeath))
            return;

        currentHP--;
        HP[currentHP].GetComponent<Image>().color = new Color(.5f, .5f, .5f, HP[currentHP].GetComponent<Image>().color.a);
        HP[currentHP].transform.GetChild(0).gameObject.SetActive(false);

        if (currentHP == 0 || T.instantDeath)
        {
            foreach(GameObject g in HP)
            {
                g.GetComponent<Image>().color = new Color(.5f, .5f, .5f, g.GetComponent<Image>().color.a);
                if(g.transform.childCount > 0) g.transform.GetChild(0).gameObject.SetActive(false);
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


    }
}
