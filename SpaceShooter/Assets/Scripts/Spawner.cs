
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject SpawnedEnemy;
    [SerializeField] private GameObject SpawnedSUPEREnemy;
    [SerializeField] private float BirthRate = 2f;
    [SerializeField] private float SUPERBirthRate = 20f;
    [SerializeField] private bool LRSpawner = false;
    [SerializeField] private UIManager UIMan;
    [SerializeField] private float DifficultyRate = 20;
    [SerializeField] private float SUPERDifficultyRate = 120;
   [SerializeField] private GameObject[] BoosterPrefabs;

    private int lastStep = 0;
    private Vector2 pivot;

    void Start()
    {
        StartCoroutine("SpawnEnemy");
        StartCoroutine("SpawnSUPEREnemy");
        StartCoroutine("DifficultyBump");
        StartCoroutine("SUPERDifficultyBump");
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(BirthRate);

        pivot = transform.position;
        
        Vector2 RandomPos;

        if(LRSpawner == true)
        {
            RandomPos = new Vector2(pivot.x, pivot.y + Random.Range(-2f,2f));
        }
        else
        {
            RandomPos = new Vector2(pivot.x + Random.Range(-2f,2f), pivot.y);
        }


        Instantiate(SpawnedEnemy, RandomPos, Quaternion.identity);

        StartCoroutine("SpawnEnemy");
    }

    IEnumerator SpawnSUPEREnemy()
    {
        yield return new WaitForSeconds(SUPERBirthRate);

        Vector2 RandomPos;

        if(LRSpawner == true)
        {
            RandomPos = new Vector2(pivot.x, pivot.y + Random.Range(-2f,2f));
        }
        else
        {
            RandomPos = new Vector2(pivot.x + Random.Range(-2f,2f), pivot.y);
        }

        Instantiate(SpawnedSUPEREnemy, RandomPos, Quaternion.identity);

        StartCoroutine("SpawnSUPEREnemy");

    }

    IEnumerator DifficultyBump()
    {
        yield return new WaitForSeconds(DifficultyRate);
        BirthRate = BirthRate - 0.2f;
        StartCoroutine("DifficultyBump");
    }
     IEnumerator SUPERDifficultyBump()
    {
        yield return new WaitForSeconds(SUPERDifficultyRate);
        SUPERBirthRate = SUPERBirthRate - 0.2f;
        StartCoroutine("SUPERDifficultyBump");
    }

    void Update()
    {
        int totalScore = UIMan.totalScore;
        int currentStep = totalScore / 2000;
        if(currentStep > lastStep)
        {
            int stepsToSpawn = currentStep - lastStep;
            for (int i = 0; i < stepsToSpawn; i++)
            {
               SpawnBooster();
            }
            lastStep = currentStep;
        }
        
    }
    void SpawnBooster()
    {
        int randomIndex = Random.Range(0, BoosterPrefabs.Length);
        GameObject selectedBooster = BoosterPrefabs[randomIndex];

        
        Vector2 RandomPos;

        if(LRSpawner == true)
        {
            RandomPos = new Vector2(pivot.x, pivot.y + Random.Range(-2f,2f));
        }
        else
        {
            RandomPos = new Vector2(pivot.x + Random.Range(-2f,2f), pivot.y);
        }

        Instantiate(selectedBooster, RandomPos, Quaternion.identity);
    }
}

