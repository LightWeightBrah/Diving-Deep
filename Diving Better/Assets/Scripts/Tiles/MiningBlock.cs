using System;
using System.Collections;
using UnityEngine;

public class MiningBlock : MonoBehaviour
{
    [SerializeField] private TileData tileData;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private const float TIME_TO_FADE_WHITE = 1.0f;
    private const float FADING_SPEED = 1.5f;
    private float health;
    private float damageTimer;

    private void Awake()
    {
        this.health = this.tileData.MaxHealth;
    }

    private void Update()
    {
        this.damageTimer += Time.deltaTime;
        if (this.damageTimer > TIME_TO_FADE_WHITE)
            this.FadeBlockToWhite();
    }

    private void FadeBlockToWhite()
    {
        this.spriteRenderer.color = Color.Lerp(this.spriteRenderer.color, Color.white, FADING_SPEED * Time.deltaTime);
    }

    public void DealDamage(float damage, float timeBetweenDamage)
    {
        if (this.damageTimer < timeBetweenDamage)
            return;
        else
            this.damageTimer = 0;

        this.spriteRenderer.color = Color.red;
        this.health -= damage;
        if (this.health <= 0)
            this.DestroyTile();
    }


    private void DestroyTile()
    {
        Inventory.instance.AddItem(this.tileData.ItemToDrop, this.tileData.AmountToDrop);
        Destroy(this.gameObject);
    }
}
