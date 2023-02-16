using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Heart _imagePrefab;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChanged += DestroyHeart;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= DestroyHeart;
    }

    private void Start()
    {
        SpawnHeart();
    }

    private void SpawnHeart()
    {
        for (int i = 0; i < _player.Lives; i++)
        {
            Instantiate(_imagePrefab, transform);
        }
    }

    private void DestroyHeart()
    {
        if (_player.Lives >= 0)
            Destroy(GetComponentInChildren<Heart>().gameObject);
    }
}
