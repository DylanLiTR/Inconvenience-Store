using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;
    
    public Inventory() {
        itemList = new List<Item>();

        /* AddItem(new Item{ itemType=Item.ItemType.ketchup, amount=1 } );
        AddItem(new Item{ itemType=Item.ItemType.sandwich, amount=1 } ); 
        AddItem(new Item{ itemType=Item.ItemType.spy, amount=1 } ); */
        
    }

    public void AddItem(Item item) {
        itemList.Add(item);
    }

    public List<Item> GetItemList() {
        return itemList;
    }

    public int GetListSize() {
        return itemList.Count;
    }

    public void RemoveFirstItem() {
        if (itemList.Count > 0) {
            itemList.RemoveAt(0);
        }
    }

    public void RemoveItem(Item item) {
        itemList.Remove(item);
    }

    public Item getItem(int i) {
        return itemList[i];
    }

    public void Removeat(int i) {
        itemList.RemoveAt(i);
    }

}
