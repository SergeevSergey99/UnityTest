using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> Items;
    public GameObject ItemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < Items.Count && i < transform.childCount; i++)
        {
            var go = Instantiate(ItemPrefab, transform.GetChild(i));
            go.GetComponent<Image>().sprite = Items[i].Icon;
            go.GetComponent<InventoryItem>().itemData = Items[i];
        }
    }

}
