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
    [SerializeField] List<GameObject> shooterIntro;
    [SerializeField] List<GameObject> shooterMedley;
    [SerializeField] List<GameObject> POMedley;
    [SerializeField] List<GameObject> PSMedley;
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

    int firstEnemy = 0;
    int secondEnemy = 1;
    int thirdEnemy = 2;


    Vector3 currentSpawnPoint;

    List<List<GameObject>> introList;
    List<List<GameObject>> singleMedleyList;
    List<List<List<GameObject>>> doubleMedleyList;

    private void Awake()
    {
        introList = new List<List<GameObject>>() { patrolIntro, orbIntro, shooterIntro };
        singleMedleyList = new List<List<GameObject>>() { patrolMedley, orbMedley, shooterMedley };
        doubleMedleyList = new List<List<List<GameObject>>>() { new List<List<GameObject>>() { null, POMedley, PSMedley },
                                                                new List<List<GameObject>>() { POMedley, null , null },
                                                                new List<List<GameObject>>() { PSMedley, null, null } };
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
            else if (!secondMedleyDone)
                DoubleMedley(firstEnemy, secondEnemy);
            else if (!thirdIntroDone)
                BasicIntro(thirdEnemy);
            else if (!thirdMedleyDone)
                DoubleMedley(0, thirdEnemy);
            return;
        }

        Instantiate(fixedLevels[index], currentSpawnPoint, Quaternion.identity, transform);

        index++;
    }

    void BasicIntro(int introID)
    {
        List<GameObject> thisIntro = introList[introID];

        if(thisIntro[subIndex] !=null)
            Instantiate(thisIntro[subIndex], currentSpawnPoint, Quaternion.identity, transform);
        else
        {
            List<GameObject> thisAdvancedIntro = singleMedleyList[introID];
            int i = Random.Range(0, thisAdvancedIntro.Count);
            Instantiate(thisAdvancedIntro[i], currentSpawnPoint, Quaternion.identity, transform);
        }
        subIndex++;
        if (subIndex >= introList[introID].Count)
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

    void DoubleMedley(int ID1, int ID2)
    {
        List<GameObject> thisMedley = doubleMedleyList[ID1][ID2];

        int i = Random.Range(0, thisMedley.Count);
        Instantiate(thisMedley[i], currentSpawnPoint, Quaternion.identity, transform);
        subIndex++;
        if (subIndex >= secondMedleyDuration && !secondMedleyDone)
        {
            secondMedleyDone = true;
            subIndex = 0;
            index++;
        }
        else if (subIndex >= thirdMedleyDuration && secondMedleyDone)
        {
            thirdMedleyDone = true;
            subIndex = 0;
            index++;
        }
    }
}
