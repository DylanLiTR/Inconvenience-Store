using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer
{
    public Inventory inventory;
    public float time;

     public Customer(Inventory inventory, float t) {
        this.inventory = inventory;
        time = t;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
