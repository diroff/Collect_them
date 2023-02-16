using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _lives;

    [SerializeField] private Level _level;

    private int _score;

    public int Score => _score;
    public int Lives => _lives;

    public event UnityAction HealthChanged;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction<bool> Dead;

    private void Start()
    {
        _score = 0;
    }

    public void ApplyDamage(int damage)
    {
        _lives -= damage;
        HealthChanged?.Invoke();

        if (_lives <= 0)
            Dead?.Invoke(true);
    }

    public void ApplyScore(int score)
    {
        _score += score;
        ScoreChanged?.Invoke(_score);
    }

    private void Update()
    {
        if(!_level.IsGameOver)
            TryHitItem();
    }

    private void TryHitItem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if (hit.collider != null)
            {
                Item currentItem = hit.collider.GetComponent<Item>();

                ApplyScore(currentItem.ScoreBonus);
                
                if (!currentItem.IsBonus)
                    ApplyDamage(1);
                
                Destroy(currentItem.gameObject);
            }
        }
    }
}