using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventorySlot[] inventorySlots;

    private void Awake()
    {
        InitializeSlots();
    }

    public void AddItem(Item item, int amount)
    {
        var slot = inventorySlots.Where(t => t.Item == item).FirstOrDefault();
        Debug.Log($"slot is: {slot}");
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
