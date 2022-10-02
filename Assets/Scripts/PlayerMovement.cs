using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	private Inventory inventory;

   public CharacterController2D controller;
   public Animator animator;
   public int totalItems=0;
   public int ketchup = 0;

   public Text TotalItems;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	
	void Start() {
		TotalItems.text=totalItems.ToString();

		inventory = new Inventory();
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

	private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "ketchup")
            {
                if (totalItems < 3)
                {
                    ketchup += 1;
                    totalItems += 1;
                    collision.gameObject.SetActive(false);
                    TotalItems.text=totalItems.ToString();

					StartCoroutine(Respawn(collision,4));
                }
            }
        }
}
