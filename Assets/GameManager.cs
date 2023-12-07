using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject doodler;
    public GameObject plateformPrefab;
    public GameObject plateformMovePrefab;
    public GameObject plateformBrokePrefab;
    public GameObject capPrefab;


    private Vector3 spawnPosition;

    private int generation = 300;
    private int nextPlateform1, nextPlateform2,only1broke = 1, nextCap;


    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = new Vector3();
        Generate();

    }

    void Generate()
    {
        for (int i = 0; i < generation; i++)
        {
            nextPlateform1 = Random.Range(1, 8);
            nextPlateform2 = Random.Range(1, 10);
            nextCap = Random.Range(1, 15);

            if (nextPlateform1 == 1 && only1broke == 0)
            {
                spawnPosition.y += Random.Range(.5f, 2f);
                spawnPosition.x = Random.Range(-2f, 2f);
                Instantiate(plateformBrokePrefab, spawnPosition, Quaternion.identity);
                only1broke = 1;
            }
            else
            {
                only1broke = 0;
                if (nextPlateform2 == 1)
                {
                        spawnPosition.y += Random.Range(.5f, 2f);
                        spawnPosition.x = Random.Range(-2f, 2f);
                        Instantiate(plateformMovePrefab, spawnPosition, Quaternion.identity);
                }

                else
                { 
                    spawnPosition.y += Random.Range(.5f, 2f);
                    spawnPosition.x = Random.Range(-2f, 2f);
                    Instantiate(plateformPrefab, spawnPosition, Quaternion.identity);
                }
            }

            if (nextCap == 1)
            {
                spawnPosition.y += 0.32f;
                spawnPosition.x = spawnPosition.x + Random.Range(-0.4f, 0.4f);
                Instantiate(capPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (doodler.transform.position.y > spawnPosition.y - 50)
            Generate();
    }
}
