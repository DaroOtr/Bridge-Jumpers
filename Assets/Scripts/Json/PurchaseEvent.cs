using Unity.Services.Analytics;

public class PurchaseEvent : Event
{
    public PurchaseEvent() : base("Bridge_Jumpers_PurchaseReport")
    {
        
    }
    public string ItemName { set { SetParameter("Purchase_ItemName", value); } }
    public int ItemValue { set { SetParameter("Purchase_ItemValue", value); } }
    public int ItemIndex { set { SetParameter("Purchase_ItemIndex", value); } }
}
