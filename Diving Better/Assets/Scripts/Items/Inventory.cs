using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    [SerializeField] private InventorySlot[] inventorySlots;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        this.InitializeSlots();
    }

    public void AddItem(Item item, int amount)
    {
        var slot = inventorySlots.Where(t => t.Item == item).FirstOrDefault();
        slot.IncreaseItemAmount(amount);
    }

    private void InitializeSlots()
    {
        foreach (var inventorySlot in inventorySlots)
        {
            inventorySlot.UpdateAmountText(0);
            inventorySlot.UpdateItemIcon(inventorySlot.Item.Icon);
        }
    }
}
