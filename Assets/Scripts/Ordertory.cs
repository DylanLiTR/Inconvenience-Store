using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordertory
{
    private List<Item> orderList;
    
    public Ordertory() {
        orderList = new List<Item>();
    }

    public void AddItem(Item item) {
        orderList.Add(item);
    }

    public List<Item> GetItemList() {
        return orderList;
    }

    public int GetListSize() {
        return orderList.Count;
    }

    public void RemoveItem(Item item) {
        orderList.Remove(item);
    }

    public void ClearList() {
        while (orderList.Count != 0) {
            orderList.RemoveAt(0);
        }
    }
}
