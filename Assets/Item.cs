using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private Color color;
    private float posX;
    private float posY;

    public Item(Color color, float posX, float posY)
    {
        this.color = color;
        this.posX = posX;
        this.posY = posY;
    }

    public Color GetColor()
    {
        return this.color;
    }
}
