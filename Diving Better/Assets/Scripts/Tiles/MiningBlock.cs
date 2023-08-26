using System;
using System.Collections;
using UnityEngine;

public class MiningBlock : MonoBehaviour
{
    [SerializeField] private TileData tileData;
    [SerializeField] private float health;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool canTakeDamage = true;

    private void Awake()
    {
        this.health = this.tileData.MaxHealth;
    }

    public void DealDamage(float damage, float timeBetweenDamage)
    {
        if (!this.canTakeDamage)
            return;

        this.spriteRenderer.color = Color.red;
        this.health -= damage;
        if (this.health <= 0)
            this.DestroyTile();

        StartCoroutine(this.DamageTimer(timeBetweenDamage));
    }

    private IEnumerator DamageTimer(float timeBetweenDamage)
    {
        this.canTakeDamage = false;
        yield return timeBetweenDamage;
        this.canTakeDamage = true;
        this.spriteRenderer.color = Color.white;
    }


    private void DestroyTile()
    {
        Inventory.instance.AddItem(this.tileData.ItemToDrop, this.tileData.AmountToDrop);
        Destroy(this.gameObject);
    }
}
