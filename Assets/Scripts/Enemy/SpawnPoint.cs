using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemys;
    [SerializeField] private float _spawnColldown;

    private List<Spawner> _spawners = new List<Spawner>();
    private Coroutine _spawn;
    private WaitForSeconds _timer;

    private void Start()
    {
        _spawners.AddRange(GetComponentsInChildren<Spawner>());
        _timer = new WaitForSeconds(_spawnColldown);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _spawn = StartCoroutine(EnemysSpawn());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            StopCoroutine(_spawn);
        }
    }

    private IEnumerator EnemysSpawn()
    {
        bool isRun = true;

        while (isRun)
        {
            _spawners[Random.Range(0, _spawners.Count)].EnemySpawn(_enemys[Random.Range(0, _enemys.Length - 1)]);

            yield return _timer;
        }
    }
}
