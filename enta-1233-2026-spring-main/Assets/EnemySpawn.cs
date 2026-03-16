using UnityEngine;
using System;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;

    private void Start()
    {
        SpawnEnemy(transform.position, transform.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward * 3);
    }

    public void SpawnEnemy(Vector3 position, Quaternion rotation)
    {
        Instantiate(_enemyPrefab, position, rotation);
        Debug.Log($"{_enemyPrefab.name} spawned");
    }
}
