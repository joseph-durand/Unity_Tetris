using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Layers : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject square1;
    public GameObject square2;
    public GameObject square3;
    public GameObject square4;

    public enum Rot
    {
        Base,
        One,
        Two,
        Three
    }

    private Rot phase;

    public Layers.Rot getPhase()
    {
        return phase;
    }
    
    

    public void nextPhase()
    {
        if (phase == Rot.Base)
            phase = Rot.One;
        else if (phase == Rot.One)
            phase = Rot.Two;
        else if (phase == Rot.Two)
            phase = Rot.Three;
        else
        {
            phase = Rot.Base;
        }
    }

    //Initialization of the layers
    public abstract void StartLayers();

    private void Start()
    {
        StartLayers();
        phase = Rot.Base;
    }

    //Rotate the piece
    public abstract void Rotate();

    //Return the x pos the next left of the piece (Used to test if a piece can rotate on the left side)
    public abstract int newLeft();
    //Return the x pos the next right of the piece (Used to test if a piece can rotate on the right side)
    public abstract int newRight();

    //Return the new squares that will appear after a rotation (Used to test if a piece can rotate)
    public abstract List<GameObject> newSquares();

    //Leave the active squares of piece and destroy the prefab
    public void Detach()
    {
        square1 = Instantiate(square1, square1.transform.position, square1.transform.rotation);
        square2 = Instantiate(square2, square2.transform.position, square2.transform.rotation);
        square3 =Instantiate(square3, square3.transform.position, square3.transform.rotation);
        square4 = Instantiate(square4, square4.transform.position, square4.transform.rotation);
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
}
