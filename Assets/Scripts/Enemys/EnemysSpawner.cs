using System.Collections;
using UnityEngine;

public class EnemysSpawner : MonoBehaviour
{
    [SerializeField] private EnemysMovement _enemysMovement;
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private float _delay;

    private void Start()
    {
        //SpawnLowEnemy(4, 1);
        GameObject enemy = Instantiate(_enemyPrefab[0], _spawnPoint[0].position, Quaternion.identity);
        _enemysMovement.AddAgent(enemy);
    }

    public void SpawnLowEnemy(int num, int maxIndex)
    {
        StartCoroutine(Spawn(num, maxIndex));
    }

    private IEnumerator Spawn (int num, int maxIndex)
    {
        for (int i = 0; i < num; i++)
        {
            SpawnRandomEnemy(maxIndex);
            yield return new WaitForSeconds(_delay);
        }
    }

    private void SpawnRandomEnemy(int maxIndex)
    {
        int randomEnemy = Random.Range(0, maxIndex);
        int randomPoint = Random.Range(0, _spawnPoint.Length);

        GameObject enemy = Instantiate(_enemyPrefab[randomEnemy], _spawnPoint[randomPoint].position, Quaternion.identity);
        _enemysMovement.AddAgent(enemy);
    }
}
