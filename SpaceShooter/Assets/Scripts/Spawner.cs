using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject SpawnedEnemy;
    [SerializeField] private float BirthRate = 2f;
    [SerializeField] private bool LRSpawner = false;
    [SerializeField] private GameObject UIMan;
    [SerializeField] private float DifficultyRate = 20;

    void Start()
    {
        StartCoroutine("SpawnEnemy");
        StartCoroutine("DifficultyBump");
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(BirthRate);

        Vector2 pivot = transform.position;

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

    IEnumerator DifficultyBump()
    {
        yield return new WaitForSeconds(DifficultyRate);
        BirthRate = BirthRate - 0.2f;
        StartCoroutine("DifficultyBump");
    }
}

