using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayersSquare : Layers
{
    public override void Rotate()
    {
        return;
    }

    public override int newLeft()
    {
        return (int) (square1.transform.position.x - 0.5f);
    }

    public override int newRight()
    {
        return (int) (square2.transform.position.x - 0.5f);
    }

    public override List<GameObject> newSquares()
    {
        return new List<GameObject>();
    }

    public override void StartLayers()
    {
        GameObject piece1 = transform.GetChild(0).gameObject;
        GameObject piece2 = transform.GetChild(1).gameObject;
        GameObject piece3 = transform.GetChild(3).gameObject;
        GameObject piece4 = transform.GetChild(2).gameObject;
        square1 = piece1;
        square2 = piece2;
        square3 = piece3;
        square4 = piece4;
    }
}
