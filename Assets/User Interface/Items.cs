using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public Sprite spriteTagebuchEintrag14Mai;
    // Start is called before the first frame update
    void Start()
    {
        
    }

  
    public Item[] getItems()
    {
        

        Item tagebuchEintrag14Mai = new Item(
            100,
            "Hello, das ist eine Beispielantwort",
            spriteTagebuchEintrag14Mai
           
        );

        Item[] ItemArray = { tagebuchEintrag14Mai};

        return ItemArray;

    }
}
