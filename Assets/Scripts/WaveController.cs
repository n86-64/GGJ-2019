using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public static WaveController instance;

    public GameObject ratPrefab;
    public GameObject burglarPrefab;
    public GameObject clubberPrefab;

    public Vector2 positionOffset;

    public Wave[] waves;

    [HideInInspector]
    public int currentWave = 0;

    [HideInInspector]
    public List<GameObject> activeUnits = new List<GameObject>();

    private void Start()
    {
        if (instance == null)
            instance = this;

        StartCoroutine(SpawnNextWave());
    }

    public IEnumerator SpawnNextWave()
    {
        Wave newWave = waves[currentWave];

        foreach (EnemySpawn group in newWave.enemies)
        {
            for (int i = 0; i < group.count; i++)
            {
                GameObject unit = Instantiate(GetPrefab(group.type));
                float randX = (float)(Random.Range(positionOffset.x * 10, positionOffset.y * 10) / 10);
                float randZ = (float)(Random.Range(positionOffset.x * 10, positionOffset.y * 10) / 10);
                unit.GetComponent<Enemy>().origin = group.route.masterPositions[0].position;
                unit.GetComponent<Enemy>().offsetPosition = new Vector3(randX, unit.transform.position.y, randZ);
                unit.GetComponent<Enemy>().type = group.type;
                unit.GetComponent<Movement>().routeController = group.route;
                //unit.transform.localScale *= 0.4f;
                unit.SetActive(true);
                activeUnits.Add(unit);

                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(group.intervalUntilNext);
        }

        if (waves.Length > currentWave)
        {
            StartCoroutine(WaitForNewWave(newWave.timeBeforeNextSpawn));
            currentWave++;
        }
        else
        {
            Debug.Log("Waves complete");
        }
    }

    public GameObject GetPrefab(EnemyType t)
    {
        switch (t)
        {
            case EnemyType.RATS:
                return ratPrefab;
            case EnemyType.BURGLARS:
                return burglarPrefab;
            case EnemyType.CLUBBERS:
                return clubberPrefab;
            default:
                return null;
        }
    }

    IEnumerator WaitForNewWave(int t)
    {
        while (activeUnits.Count > 0)
        {
            yield return null;
        }

        if (ObjectiveData.instance.HaveTheRent())
        {
            yield return new WaitForSeconds(t);
            StartCoroutine(SpawnNextWave());
        }
    }
}
