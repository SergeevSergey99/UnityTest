using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRenderer : MonoBehaviour
{
    public Text Name; 
    public Text Description; 
    public Text Cost; 
    public Text Weigth; 
    public Image Icon;

    public void RenderItem(Item item)
    {
        Name.text = item.Name;
        Description.text = item.Description;
        Cost.text = "Цена = " + item.Cost;
        Weigth.text = "Вес = " + item.Weight;
        Icon.sprite = item.Icon;
    }
}
