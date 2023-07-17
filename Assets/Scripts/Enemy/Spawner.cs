using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void EnemySpawn(Enemy enemy)
    {
        Instantiate(enemy, this.transform.position, Quaternion.identity);
    }
}
