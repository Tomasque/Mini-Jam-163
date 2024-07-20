using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawn : MonoBehaviour
{
    int index;
    [SerializeField] List<GameObject> fixedLevels;
    [SerializeField] List<GameObject> patrolIntro;
    [SerializeField] List<GameObject> patrolMedley;
    [SerializeField] List<GameObject> orbIntro;
    [SerializeField] List<GameObject> orbMedley;
    [SerializeField] List<GameObject> POMedley;
    int subIndex;
    bool firstIntroDone;
    [SerializeField] int firstMedleyDuration;
    bool firstMedleyDone;
    bool secondIntroDone;
    [SerializeField] int secondMedleyDuration;
    bool secondMedleyDone;
    bool thirdIntroDone;
    [SerializeField] int thirdMedleyDuration;
    bool thirdMedleyDone;

    [SerializeField] int firstEnemy;
    [SerializeField] int secondEnemy;


    Vector3 currentSpawnPoint;

    List<List<GameObject>> introList;
    List<List<GameObject>> singleMedleyList;
    List<List<List<GameObject>>> doubleMedleyList;

    private void Awake()
    {
        introList = new List<List<GameObject>>() { patrolIntro, orbIntro, null };
        singleMedleyList = new List<List<GameObject>>() { patrolMedley, orbMedley, null };
        doubleMedleyList = new List<List<List<GameObject>>>() { new List<List<GameObject>>() { null, POMedley, null },
                                                                new List<List<GameObject>>() { POMedley, null , null },
                                                                new List<List<GameObject>>() { null, null, null } };
    }

    public void SpawnLevel(float spawnOffset)
    {
        currentSpawnPoint = new Vector3(transform.position.x, transform.position.y + spawnOffset, 0);

        if(fixedLevels[index] == null)
        {
            if (!firstIntroDone)
                BasicIntro(firstEnemy);
            else if (!firstMedleyDone)
                SingleMedley(firstEnemy);
            else if (!secondIntroDone)
                BasicIntro(secondEnemy);
            return;
        }

        Instantiate(fixedLevels[index], currentSpawnPoint, Quaternion.identity, transform);

        index++;
    }

    void BasicIntro(int introID)
    {
        List<GameObject> thisIntro = introList[introID];

        Instantiate(thisIntro[subIndex], currentSpawnPoint, Quaternion.identity, transform);
        subIndex++;
        if (subIndex >= introList[firstEnemy].Count)
        {
            if (!firstIntroDone)
                firstIntroDone = true;
            else if (!secondIntroDone)
                secondIntroDone = true;
            else
                thirdIntroDone = true;
            subIndex = 0;
            index++;
        }
    }

    void SingleMedley(int medleyID)
    {
        List<GameObject> thisMedley = singleMedleyList[medleyID];

        int i = Random.Range(0, thisMedley.Count);
        Instantiate(thisMedley[i], currentSpawnPoint, Quaternion.identity, transform);
        subIndex++;
        if (subIndex >= firstMedleyDuration) //the only single medley is the first medley
        {
            firstMedleyDone = true;
            subIndex = 0;
            index++;
        }
    }
}
