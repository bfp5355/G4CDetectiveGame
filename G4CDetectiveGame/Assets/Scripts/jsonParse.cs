using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

//lets unity know we intend toi serialize this class
[System.Serializable]
public class Item //Item class
{
    public string name;
    public string text;
}

[System.Serializable]
public class ItemList //Item List class
{
    public List<Item> items;
}

public class jsonParse
{
    /// <summary>
    /// deserializes a single items
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    public static Item DeserializeSingleItem(string json)
    {
        Item item = new Item();
        item = JsonUtility.FromJson<Item>(json);

        if(item != null)
        {
            return item;
        }
        return null;
    }

    public static List<Item> DeserializeList(string json)
    {
        ItemList itemList = new ItemList();

        itemList = JsonUtility.FromJson<ItemList>(json);

        return itemList.items;
    }
    
}
