using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public Item itemData;

    public void Render()
    {
        FindObjectOfType<ItemRenderer>().RenderItem(itemData);
    }
}
