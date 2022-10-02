using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;
    private int numberOfItems = 0;
    public Inventory() {
        itemList = new List<Item>();

        /* AddItem(new Item{ itemType=Item.ItemType.ketchup, amount=1 } );
        AddItem(new Item{ itemType=Item.ItemType.sandwich, amount=1 } ); 
        AddItem(new Item{ itemType=Item.ItemType.spy, amount=1 } ); */
        
    }

    public void AddItem(Item item) {
        itemList.Add(item);
        numberOfItems++;
    }

    public List<Item> GetItemList() {
        return itemList;
    }

    public int GetListSize() {
        return numberOfItems;
    }

    public void RemoveItem(Item item) {
        itemList.Remove(item);
        numberOfItems--;
    }
}
