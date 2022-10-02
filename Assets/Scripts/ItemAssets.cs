using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Start () {
        Instance = this;
    }

    public Transform pfItemWorld;

    public Sprite ketchupSprite;
    public Sprite sandwichSprite;
    public Sprite milkSprite;
    public Sprite spySprite;
    public Sprite appleSprite;

}
