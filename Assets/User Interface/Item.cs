using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class Item
{
    public int id;
    Sprite model;
    bool found = false;
    public string response;

    public Item(int id, string response, Sprite model)
    {
        this.id = id;
        this.response = response;
        this.model = model;
    }

    public void setFound(bool found)
    {
        this.found = found;
    }
}
