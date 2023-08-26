using UnityEngine;

public class Slot : MonoBehaviour
{
    public Item Item => this.item;

    [SerializeField] private Item item;
    protected int amount;

    public virtual void IncreaseItemAmount(int amount)
    {
        this.amount += amount;
    }

    public virtual void DecreaseItemAmount(int amount) 
    {  
        this.amount -= amount;
    }
}
