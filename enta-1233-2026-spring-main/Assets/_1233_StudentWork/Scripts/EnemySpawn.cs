using UnityEngine;
using System;

public class EnemySpawn : MonoBehaviour
{
    public enum SpawnType
    {
        OnStart,
        OnTrigger
    }

    [SerializeField] private SpawnType _spawnMode = SpawnType.OnStart;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _spawnPoint;
    private bool _hasSpawned = false;
    
    private void Start()
    {
        if (_spawnMode == SpawnType.OnStart)
        {
            SpawnEnemy(transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_spawnMode != SpawnType.OnTrigger) return;
        if (other.CompareTag("Player"))
        {
            SpawnEnemy(_spawnPoint.transform.position, _spawnPoint.transform.rotation);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward * 3);
    }

    public void SpawnEnemy(Vector3 position, Quaternion rotation)
    {
        if (!_hasSpawned)
        {
            Instantiate(_enemyPrefab, position, rotation);
            Debug.Log($"{_enemyPrefab.name} spawned");
            _hasSpawned = true;
        }
        
    }
}
