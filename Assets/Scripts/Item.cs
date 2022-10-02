using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType {
        ketchup,
        sandwich,
        milk,
        spy,
        apple
    }
    public ItemType itemType;


    public Sprite GetSprite() {
        switch (itemType) {
            default:
            case ItemType.ketchup: return ItemAssets.Instance.ketchupSprite;
            case ItemType.sandwich: return ItemAssets.Instance.sandwichSprite;
            case ItemType.milk: return ItemAssets.Instance.milkSprite;
            case ItemType.spy: return ItemAssets.Instance.spySprite;
            case ItemType.apple: return ItemAssets.Instance.appleSprite;
        }
    }
}
