using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideDestroyer : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.gameObject.GetComponent<Item>();

        if (item.IsBonus)
            _player.ApplyDamage(1);

        Destroy(collision.gameObject);
    }
}