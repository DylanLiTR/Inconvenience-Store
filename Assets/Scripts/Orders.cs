using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orders : MonoBehaviour
{
    private Inventory inventory;
    
    const int numOfItems = 5;
    bool playerVisit = true;

    private class Order = {
        List<Item> items;
        int timer = 60;
    }
    
    int itemInOrder(Item item, Order order) {
        int numitems = order.items.Count;
        for (int i; i < numitems; ++i) {
            if (item == order.items[i]) {
                order.RemoveAt(i);
                inventory.RemoveItem(item);
                break;
            }
        }
    }

  

    public void depositItems(itemlist, order) {
        foreach (Item item in inventory.GetItemList()) {
            itemInOrder(item, order);
        }
        /* if (order.Count == 0) {

        } */
    }

    // Start is called before the first frame update
    void Start()
    {
        /* Order custOrder = new Order;
        custOrder[0] = 1;       // Sample first order */
    }

    // Update is called once per frame
    void Update()
    {

    }
}