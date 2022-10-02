using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	private Inventory inventory;
	[SerializeField] private InventoryUI inventoryUI;

   public CharacterController2D controller;
   public int totalItems=0;
   public int ketchup = 0;

   public Text TotalItems;

	public float runSpeed = 40f;

	const int maxItems = 3;
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	
	void Start() {
		TotalItems.text=totalItems.ToString();

		inventory = new Inventory();
		inventoryUI.SetInventory(inventory);

		/* ItemWorld.SpawnItemWorld(new Vector3(10,10), new Item {itemType = Item.ItemType.apple, amount =1});
		ItemWorld.SpawnItemWorld(new Vector3(-10,10), new Item {itemType = Item.ItemType.milk, amount =1});
		ItemWorld.SpawnItemWorld(new Vector3(0,-10), new Item {itemType = Item.ItemType.spy, amount =1}); */
	}

	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}

        /*if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
*/
        
    }

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

	IEnumerator Respawn (Collider2D collision, float time) {
		yield return new WaitForSeconds(time);
		collision.gameObject.SetActive(true);
	}

	private void OnTriggerEnter2D(Collider2D collision)
        {
			// ketchup collision
            if (collision.gameObject.tag == "ketchup")
            {
                if (inventory.GetListSize() < maxItems)
                {
                    inventory.AddItem(new Item{ itemType=Item.ItemType.ketchup, amount=1 } );
                    collision.gameObject.SetActive(false);
					inventoryUI.SetInventory(inventory);

					StartCoroutine(Respawn(collision,4));
                }
            }
			// sandwich collision
			if (collision.gameObject.tag == "sandwich")
            {
                if (inventory.GetListSize() < maxItems)
                {
                    inventory.AddItem(new Item{ itemType=Item.ItemType.sandwich, amount=1 } );
                    collision.gameObject.SetActive(false);
					inventoryUI.SetInventory(inventory);

					StartCoroutine(Respawn(collision,8));
                }
            }
			// milk collision
			if (collision.gameObject.tag == "milk")
            {
                if (inventory.GetListSize() < maxItems)
                {
                    inventory.AddItem(new Item{ itemType=Item.ItemType.milk, amount=1 } );
                    collision.gameObject.SetActive(false);
					inventoryUI.SetInventory(inventory);

					StartCoroutine(Respawn(collision,12));
                }
            }
			// apple collision
			if (collision.gameObject.tag == "apple")
            {
                if (inventory.GetListSize() < maxItems)
                {
                    inventory.AddItem(new Item{ itemType=Item.ItemType.apple, amount=1 } );
                    collision.gameObject.SetActive(false);
					inventoryUI.SetInventory(inventory);

					StartCoroutine(Respawn(collision,16));
                }
            }
			// spy collision
			if (collision.gameObject.tag == "spy")
            {
                if (inventory.GetListSize() < maxItems)
                {
                    inventory.AddItem(new Item{ itemType=Item.ItemType.spy, amount=1 } );
                    collision.gameObject.SetActive(false);
					inventoryUI.SetInventory(inventory);

					StartCoroutine(Respawn(collision,20));
                }
            }
			// trash collision
			if (collision.gameObject.tag == "trash")
            {
				foreach (Item item in inventory.GetItemList()) {
					// Drop all items for now
					inventory.RemoveItem(item);
					inventoryUI.SetInventory(inventory);
				}
            }
			// desk collision
			if (collision.gameObject.tag == "desk")
			{
				itemlist = new List<Item>();
				itemlist = inventory.GetItemList();
				depositItems(itemlist, order);
			}
        }
}
