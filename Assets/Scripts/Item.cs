using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _scoreBonus;
    [SerializeField] private bool _isBonus;

    public int ScoreBonus => _scoreBonus;
    public bool IsBonus => _isBonus;

    private void Update()
    {
        MoveDown();
    }

    private void MoveDown()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
}