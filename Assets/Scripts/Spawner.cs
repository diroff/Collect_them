using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private List<Item> _items;
    [SerializeField] private float _delay;

    [SerializeField] private Level _level;

    [SerializeField] private float _leftSpawnCorner;
    [SerializeField] private float _rightSpawnCorner;

    private float _currentTime;

    private void Start()
    {
        _currentTime = _delay;
    }

    private void SpawnItem()
    {
        if (_currentTime >= _delay)
        {
            Instantiate(ChooseRandomItem(), ChooseRandomSpawnPosition(), Quaternion.identity);
            _currentTime = 0;
        }
    }

    private Item ChooseRandomItem()
    {
        return _items[Random.Range(0, _items.Count)];
    }

    private Vector3 ChooseRandomSpawnPosition()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(_leftSpawnCorner, _rightSpawnCorner), _spawnPoint.position.y, _spawnPoint.position.z);

        return spawnPoint;
    }

    private void Update()
    {
        if (!_level.IsGameOver)
        {
            _currentTime += Time.deltaTime;
            SpawnItem();
        }
    }
}