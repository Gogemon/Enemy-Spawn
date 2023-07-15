using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemys;
    [SerializeField] private List<EnemySpawner> _enemysSpawners;
    [SerializeField] private float _spawnColldown;

    private float _spawnTimer;
    private Coroutine _enemysSpawn;

    private void Start()
    {
        _enemysSpawners.AddRange(GetComponentsInChildren<EnemySpawner>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _enemysSpawn = StartCoroutine(EnemysSpawn());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            StopCoroutine(_enemysSpawn);
        }
    }

    private IEnumerator EnemysSpawn()
    {
        bool isRun = true;

        _spawnTimer = 0;

        while (isRun)
        {
            _spawnTimer -= Time.deltaTime;

            if (_spawnTimer <= 0)
            {
                _spawnTimer = _spawnColldown;
                _enemysSpawners[Random.Range(0, _enemysSpawners.Count)].SpawnEnemy(_enemys[Random.Range(0, _enemys.Length - 1)]);
            }

            yield return null;
        }
    }
}
