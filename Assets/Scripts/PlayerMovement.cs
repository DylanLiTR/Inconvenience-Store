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
   List<Customer> customerList = new List<Customer>();

   public Text customerCount;
   public Animator animator;

   private int customerSize = 0;



	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	
	void Start() {

		inventory = new Inventory();
		inventoryUI.SetInventory(inventory);

		

		/* ItemWorld.SpawnItemWorld(new Vector3(10,10), new Item {itemType = Item.ItemType.apple, amount =1});
		ItemWorld.SpawnItemWorld(new Vector3(-10,10), new Item {itemType = Item.ItemType.milk, amount =1});
		ItemWorld.SpawnItemWorld(new Vector3(0,-10), new Item {itemType = Item.ItemType.spy, amount =1}); */
	}

	// Update is called once per frame
	void Update () {
		
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("Jumping", true);
		}
		// Creating a customer with a probability of 1 every 20 sec
		// getting error: object reference not set to an instanceo of an object
		// i.e. custInventory is not an instance of Inventory i.e. not initialized
		if (Random.value < Time.deltaTime/20) {
			Inventory custInventory = new Inventory();
			for (int i = 0; i < 3; ++i) {
				float order = Random.value;
				if (order < 0.3) {
					custInventory.AddItem(new Item {itemType = Item.ItemType.spy});
				} else if (order < 0.6) {
					custInventory.AddItem(new Item {itemType = Item.ItemType.apple});
				} else if (order < 0.9) {
					custInventory.AddItem(new Item {itemType = Item.ItemType.sandwich});
				} else if (order < 0.95) {
					custInventory.AddItem(new Item {itemType = Item.ItemType.milk});
				} else {
					custInventory.AddItem(new Item {itemType = Item.ItemType.ketchup});
				}
			}
		
			float timeToComplete = 40;
			Customer new_customer = new Customer (custInventory, timeToComplete);
			customerList.Add(new_customer);
			customerSize++;
		}
		// Checking how many customers have been created (like a rudimentary orders UI)
		string customer1 = "k";
		if (customerSize > 0) {
			customerSize = customerList.Count;

		
			foreach (Item item in customerList[0].inventory.GetItemList()) {
				customer1 += item.GetType();
			}
		}
		customerCount.text = customerSize.ToString() + customer1;


		// Crouching if we need it, nothing for now
        /*if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
*/
        
    }

	public void OnLanding ()
	{
		animator.SetBool("Jumping", false);
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

	void OnTriggerEnter2D(Collider2D collision)
        {
			// ketchup collision
            if (collision.gameObject.tag == "ketchup")
            {
                if (inventory.GetListSize() < 3)
                {
                    inventory.AddItem(new Item{ itemType=Item.ItemType.ketchup} );
                    collision.gameObject.SetActive(false);
					inventoryUI.SetInventory(inventory);

					StartCoroutine(Respawn(collision,4));
                }
            }
			// sandwich collision
			if (collision.gameObject.tag == "sandwich")
            {
                if (inventory.GetListSize() < 3)
                {
                    inventory.AddItem(new Item{ itemType=Item.ItemType.sandwich} );
                    collision.gameObject.SetActive(false);
					inventoryUI.SetInventory(inventory);

					StartCoroutine(Respawn(collision,8));
                }
            }
			// milk collision
			if (collision.gameObject.tag == "milk")
            {
                if (inventory.GetListSize() < 3)
                {
                    inventory.AddItem(new Item{ itemType=Item.ItemType.milk} );
                    collision.gameObject.SetActive(false);
					inventoryUI.SetInventory(inventory);

					StartCoroutine(Respawn(collision,12));
                }
            }
			// apple collision
			if (collision.gameObject.tag == "apple")
            {
                if (inventory.GetListSize() < 3)
                {
                    inventory.AddItem(new Item{ itemType=Item.ItemType.apple} );
                    collision.gameObject.SetActive(false);
					inventoryUI.SetInventory(inventory);

					StartCoroutine(Respawn(collision,16));
                }
            }
			// spy collision
			if (collision.gameObject.tag == "spy")
            {
                if (inventory.GetListSize() < 3)
                {
                    inventory.AddItem(new Item{ itemType=Item.ItemType.spy} );
                    collision.gameObject.SetActive(false);
					inventoryUI.SetInventory(inventory);

					StartCoroutine(Respawn(collision,20));
                }
            }
			// desk collision
			// Want to go through each customer in order and remove the first item we find
			// thats same as one of the iterms in the player's inventory
			if (collision.gameObject.tag == "desk")
            {
				if (customerSize > 0) {
					int invenSize = inventory.GetListSize();
					for (int i = 0; i < customerSize; ++i) {
						Customer cust = (Customer)customerList[i];
						int custInvenSize = cust.inventory.GetListSize();
						for (int j= 0; j < invenSize; ++j) {
							for (int k =0; k < custInvenSize; ++k) {
								if (inventory.getItem(j).GetType() == cust.inventory.getItem(k).GetType()) {
									inventory.Removeat(j);
									cust.inventory.Removeat(k);

									if (cust.inventory.GetListSize() == 0) {
										customerList.RemoveAt(i);
										customerSize--;
									}
								}
							}
						}
					}

				/* foreach (Customer cust in customerList) {
					foreach (Item item in inventory.GetItemList()) {
						foreach (Item item2 in cust.inventory.GetItemList()) {
							if (item == item2) {
								inventory.RemoveItem(item);
								cust.inventory.RemoveItem(item);
								if (cust.inventory.GetListSize() == 0) {
									customerList.Remove(cust);
									customerSize--;
								}
							}
						}
					}
				}*/
				}
            }

        }
}
