using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public void SpawnEnemy(Enemy enemy)
    {
        Instantiate(enemy, this.transform.position, Quaternion.identity);
    }
}
