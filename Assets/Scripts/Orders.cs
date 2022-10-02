using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orders : MonoBehaviour
{
    const int numOfItems = 5;
    bool playerVisit = true;

    class Order = {
        int[] items = {}
        int timer = 60;
    }
    
    // Checks whether an Order is fulfilled or not
    int checkOrder(class Order custOrder) {
        for (int i = 0; i < numOfItems, ++i) {
            if (custOrder.items[i] != 0) {
                return 0; // if any items left in order, return 0
            }
        }
        return 1; // if all items are done, order is fulfilled
    }

    // Start is called before the first frame update
    void Start()
    {
        custOrder = new Order;
        custOrder[0] = 1;       // Sample first order
    }

    // Update is called once per frame
    void Update()
    {
        if (/* INSERT CODE player is in/colliding with storefront */) {
            if (playerVisit) {
                for (int i = 0; i < numOfItems, ++i) {
                    if (inventory[i] >= custOrder.items[i]) {
                        inventory[i] -= custOrder.items[i];
                        custOrder.items[i] = 0;
                        checkOrder(custOrder);
                    } else if (0 < inventory[i] && inventory[i] < custOrder.items[i]) {
                        custOrder.items[i] -= inventory[i];
                        inventory[i] = 0;
                    }
                }
                playerVisit = false;
            }
        }
        else {
            playerVisit = true; // player is outside store, so check next collision
        }

        custOrder.timer -= Time.deltaTime;

        if (custOrder.timer <= 0) {
            /* INSERT CODE game over */
        }
    }
}