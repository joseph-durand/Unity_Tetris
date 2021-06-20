using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayersI : Layers
{
    
    // Start is called before the first frame update
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

    public void AllDisable()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(false);
        transform.GetChild(5).gameObject.SetActive(false);
        transform.GetChild(6).gameObject.SetActive(false);
        transform.GetChild(7).gameObject.SetActive(false);
        transform.GetChild(8).gameObject.SetActive(false);
        transform.GetChild(9).gameObject.SetActive(false);
        transform.GetChild(10).gameObject.SetActive(false);
        transform.GetChild(11).gameObject.SetActive(false);
    }

    

    public override void Rotate()
    {
        GameObject piece1 = transform.GetChild(0).gameObject;
        GameObject piece2 = transform.GetChild(1).gameObject;
        GameObject piece3 = transform.GetChild(2).gameObject;
        GameObject piece4 = transform.GetChild(3).gameObject;
        GameObject piece5 = transform.GetChild(4).gameObject;
        GameObject piece6 = transform.GetChild(5).gameObject;
        GameObject piece7 = transform.GetChild(6).gameObject;
        GameObject piece8 = transform.GetChild(7).gameObject;
        GameObject piece9 = transform.GetChild(8).gameObject;
        GameObject piece10 = transform.GetChild(9).gameObject;
        GameObject piece11 = transform.GetChild(10).gameObject;
        GameObject piece12 = transform.GetChild(11).gameObject;
        nextPhase();
        if (getPhase() == Rot.Base)
        {
            square1 = piece1;
            square2 = piece2;
            square3 = piece3;
            square4 = piece4;
            AllDisable();
            square1.SetActive(true);
            square2.SetActive(true);
            square3.SetActive(true);
            square4.SetActive(true);
        }
        else if (getPhase() == Rot.One)
        {
            square1 = piece4;
            square2 = piece8;
            square3 = piece9;
            square4 = piece12;
            AllDisable();
            square1.SetActive(true);
            square2.SetActive(true);
            square3.SetActive(true);
            square4.SetActive(true);
        }
        else if (getPhase() == Rot.Two)
        {
            square1 = piece5;
            square2 = piece6;
            square3 = piece7;
            square4 = piece8;
            AllDisable();
            square1.SetActive(true);
            square2.SetActive(true);
            square3.SetActive(true);
            square4.SetActive(true);
        }
        else
        {
            square1 = piece3;
            square2 = piece7;
            square3 = piece10;
            square4 = piece11;
            AllDisable();
            square1.SetActive(true);
            square2.SetActive(true);
            square3.SetActive(true);
            square4.SetActive(true);
        }
    }

    public override int newLeft()
    {
        if (getPhase() == Rot.Base || getPhase() == Rot.Two)
            return (int) (square1.transform.position.x - 0.5f);
        if (getPhase() == Rot.One)
            return (int) (square1.transform.position.x - 2.5f);
        return (int) (square1.transform.position.x - 1.5f);
    }

    public override int newRight()
    {
        if (getPhase() == Rot.Base || getPhase() == Rot.Two)
            return (int) (square1.transform.position.x - 0.5f);
        if (getPhase() == Rot.One)
            return (int) (square1.transform.position.x + 0.5f);
        return (int) (square1.transform.position.x + 1.5f);
    }

    public override List<GameObject> newSquares()
    {
        List<GameObject> list = new List<GameObject>();
        if (getPhase() == Rot.Base)
        {
            list.Add(transform.GetChild(7).gameObject);
            list.Add(transform.GetChild(8).gameObject);
            list.Add(transform.GetChild(11).gameObject);
        }
        else if (getPhase() == Rot.One)
        {
            list.Add(transform.GetChild(4).gameObject);
            list.Add(transform.GetChild(5).gameObject);
            list.Add(transform.GetChild(6).gameObject);
        }
        else if (getPhase() == Rot.Two)
        {
            list.Add(transform.GetChild(9).gameObject);
            list.Add(transform.GetChild(10).gameObject);
            list.Add(transform.GetChild(2).gameObject);
        }
        else
        {
            list.Add(transform.GetChild(0).gameObject);
            list.Add(transform.GetChild(1).gameObject);
            list.Add(transform.GetChild(3).gameObject);
        }

        return list;
    }

    // Update is called once per frame
    
}
