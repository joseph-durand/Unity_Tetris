using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayersT : Layers
{
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

    public override int newLeft()
    {
        if (getPhase() == Rot.Base)
            return (int)(square4.transform.position.x - 0.5f);
        return (int)(square4.transform.position.x - 1.5f);
    }

    public override int newRight()
    {
        if (getPhase() == Rot.Two)
            return (int)(square4.transform.position.x - 0.5f);
        return (int)(square4.transform.position.x + 0.5f);
    }

    public override List<GameObject> newSquares()
    {
        List<GameObject> list = new List<GameObject>();
        if (getPhase() == Rot.Base)
            list.Add(transform.GetChild(4).gameObject);
        else if (getPhase() == Rot.One)
            list.Add(transform.GetChild(1).gameObject);
        else if (getPhase() == Rot.Two)
            list.Add(transform.GetChild(0).gameObject);
        else
        {
            list.Add(transform.GetChild(3).gameObject);
        }

        return list;
    }

    public override void Rotate()
    {

        GameObject piece1 = transform.GetChild(0).gameObject;
        GameObject piece2 = transform.GetChild(1).gameObject;
        GameObject piece3 = transform.GetChild(3).gameObject;
        GameObject piece4 = transform.GetChild(4).gameObject;
        nextPhase();
        if (getPhase() == Rot.Base)
        {
            square1 = piece1;
            square2 = piece2;
            square3 = piece3;
            piece1.SetActive(true);
            piece2.SetActive(true);
            piece3.SetActive(true);
            piece4.SetActive(false);
        }
        else if (getPhase() == Rot.One)
        {
            square1 = piece1;
            square2 = piece4;
            square3 = piece3;
            piece1.SetActive(true);
            piece2.SetActive(false);
            piece3.SetActive(true);
            piece4.SetActive(true);
        }
        else if (getPhase() == Rot.Two)
        {
            square1 = piece4;
            square2 = piece2;
            square3 = piece3;
            piece1.SetActive(false);
            piece2.SetActive(true);
            piece3.SetActive(true);
            piece4.SetActive(true);
        }
        else
        {
            square1 = piece1;
            square2 = piece2;
            square3 = piece4;
            piece1.SetActive(true);
            piece2.SetActive(true);
            piece3.SetActive(false);
            piece4.SetActive(true);
        }
            
    }
}
