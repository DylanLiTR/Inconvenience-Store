using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartSpawner : MonoBehaviour
{
    [SerializeField] GameObject cartPrefab;
    [SerializeField] float respawnTime = 15f;
    [SerializeField] float randRange = 5f;
    public bool shootLeft;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wildCart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnCart() {
        GameObject cart = Instantiate(cartPrefab) as GameObject;
        cart.transform.position = transform.position;
        cart.transform.parent = gameObject.transform;
    }

    IEnumerator wildCart() {
        while (true) {
            yield return new WaitForSeconds(respawnTime + Random.Range(-randRange, randRange));
            spawnCart();
        }
    }
}
