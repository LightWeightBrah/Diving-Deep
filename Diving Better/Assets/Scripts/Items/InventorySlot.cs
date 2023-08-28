using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : Slot
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private TMP_Text amountText;

    public override void IncreaseItemAmount(int amount)
    {
        base.IncreaseItemAmount(amount);
        this.UpdateAmountText(this.amount);
    }

    public override void DecreaseItemAmount(int amount)
    {
        base.DecreaseItemAmount(amount);
        this.UpdateAmountText(this.amount);
    }

    public void UpdateAmountText(int amount)
    {
        this.amountText.SetText(amount.ToString());
    }

    public void UpdateItemIcon(Sprite icon)
    {
        this.itemIcon.sprite = icon;
    }
}
