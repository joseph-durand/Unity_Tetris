using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayersJ : Layers
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
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(false);
        transform.GetChild(5).gameObject.SetActive(false);
        transform.GetChild(6).gameObject.SetActive(false);
        transform.GetChild(7).gameObject.SetActive(false);
        transform.GetChild(8).gameObject.SetActive(false);
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
        
        nextPhase();
        if (getPhase() == Rot.Base)
        {
            square1 = piece1;
            square2 = piece2;
            square3 = piece4;
            AllDisable();
            square1.SetActive(true);
            square2.SetActive(true);
            square3.SetActive(true);
        }
        else if (getPhase() == Rot.One)
        {
            square1 = piece6;
            square2 = piece8;
            square3 = piece7;
            AllDisable();
            square1.SetActive(true);
            square2.SetActive(true);
            square3.SetActive(true);
        }
        else if (getPhase() == Rot.Two)
        {
            square1 = piece9;
            square2 = piece2;
            square3 = piece4;
            AllDisable();
            square1.SetActive(true);
            square2.SetActive(true);
            square3.SetActive(true);
        }
        else
        {
            square1 = piece6;
            square2 = piece8;
            square3 = piece5;
            AllDisable();
            square1.SetActive(true);
            square2.SetActive(true);
            square3.SetActive(true);
        }
        
        
    }

    public override int newLeft()
    {
        return (int) (transform.GetChild(1).transform.position.x - 0.5f);
    }

    public override int newRight()
    {
        return (int) (transform.GetChild(3).transform.position.x - 0.5f);
    }

    public override List<GameObject> newSquares()
    {
        List<GameObject> list = new List<GameObject>();
        if (getPhase() == Rot.Base)
        {
            list.Add(transform.GetChild(5).gameObject);
            list.Add(transform.GetChild(6).gameObject);
            list.Add(transform.GetChild(7).gameObject);
        }
        else if (getPhase() == Rot.One)
        {
            list.Add(transform.GetChild(1).gameObject);
            list.Add(transform.GetChild(3).gameObject);
            list.Add(transform.GetChild(8).gameObject);
        }
        else if (getPhase() == Rot.Two)
        {
            list.Add(transform.GetChild(4).gameObject);
            list.Add(transform.GetChild(5).gameObject);
            list.Add(transform.GetChild(7).gameObject);
        }
        else
        {
            list.Add(transform.GetChild(0).gameObject);
            list.Add(transform.GetChild(1).gameObject);
            list.Add(transform.GetChild(3).gameObject);
        }

        return list;
    }

    
}
