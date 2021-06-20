using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using TMPro;
using TreeEditor;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Quaternion = UnityEngine.Quaternion;
using Random = Unity.Mathematics.Random;
using Scene = UnityEditor.SearchService.Scene;
using Vector3 = UnityEngine.Vector3;

public class game : MonoBehaviour
{
    public int spawnPosX;
    public int spawnPosY;

    public int nextX;
    public int nextY;

    public int limLeft;
    public int limRight;
    public int limBottom;

    public int score;

    private GameObject currentObj;
    Random rand = new Unity.Mathematics.Random(1500);

    private List<GameObject[]> cases;
    private GameObject next;
    

    public GameObject[] everyPieces = new GameObject[6];

    
    
    


    //Return a random piece
    GameObject randObj()
    {
        
        return everyPieces[rand.NextUInt(0, 7)];
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
    }
    void Start()
    {
        score = 0;
        Debug.Log(transform.GetChild(0).GetChild(0).name);
        var text = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

        text.SetText("Score: " + score);
        cases = new List<GameObject[]>();
        for (int i = 0; i < 20; i++)
        {
            cases.Add(new GameObject[10] {null, null, null, null, null, null, null, null, null, null});
            Debug.Log(cases[i]);
        }
        next = Instantiate(randObj(), new Vector3(nextX, nextY, 0), new Quaternion());
        currentObj = Instantiate(randObj(), new Vector3(spawnPosX, spawnPosY, 0), new Quaternion());
        InvokeRepeating(nameof(Fall), 1f, 0.5f );
    }

    
    //Destroy every squares of the matrix (for test purpose)
    void DestroyAll()
    {
        for (int i = 0; i < cases.Count; i++)
        {
            for (int j = 0; j < cases[i].Length; j++)
            {
                var obj = cases[i][j];
                if (obj != null)
                {
                    GameObject.Destroy(obj);
                    cases[i][j] = null;

                }
            }
        }
    }

    //Destroy the line i of the matrix
    void DestroyLine(int i)
    {
        for (int j = 0; j < cases[i].Length; j++)
        {
            var obj = cases[i][j];
            GameObject.Destroy(obj);
            cases[i][j] = null;
        }

        for (int j = i + 1; j < cases.Count; j++)
        {
            for (int k = 0; k < cases[j].Length; k++)
            {
                if (cases[j][k])
                {
                    var current = cases[j][k].transform.position;
                    cases[j][k].transform.SetPositionAndRotation(new Vector3(current.x, current.y - 1, current.z), new Quaternion());
                }
                
            }
        }
        cases.RemoveAt(i);
        cases.Add(new GameObject[10] {null, null, null, null, null, null, null, null, null, null});
        score += 10;
        var text = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        text.SetText("Score: " + score);
        
    }

    //Add the squares of a pieces into the matrix
    void AddCurrent(Layers layers)
    {
        int y = (int) (layers.square1.transform.position.y - 0.5f);
        int x = (int) (layers.square1.transform.position.x - 0.5f);
        cases[y][x] = layers.square1;
        
        y = (int) (layers.square2.transform.position.y - 0.5f);
        x = (int) (layers.square2.transform.position.x - 0.5f);
        cases[y][x] = layers.square2;
        
        y = (int) (layers.square3.transform.position.y - 0.5f);
        x = (int) (layers.square3.transform.position.x - 0.5f);
        cases[y][x] = layers.square3;
        
        y = (int) (layers.square4.transform.position.y - 0.5f);
        x = (int) (layers.square4.transform.position.x - 0.5f);
        cases[y][x] = layers.square4;
    }

    //Test if the current piece can go down
    bool blockDown(Layers layers)
    {
        
        int y = (int) (layers.square1.transform.position.y - 0.5f);
        int x = (int) (layers.square1.transform.position.x - 0.5f);
        if (y == 0)
            return true;
        if (cases[y - 1][x] != null)
            return true;
        
        y = (int) (layers.square2.transform.position.y - 0.5f);
        x = (int) (layers.square2.transform.position.x - 0.5f);
        if (y == 0)
            return true;
        if (cases[y - 1][x] != null)
            return true;
        
        y = (int) (layers.square3.transform.position.y - 0.5f);
        x = (int) (layers.square3.transform.position.x - 0.5f);
        if (y == 0)
            return true;
        if (cases[y - 1][x] != null)
            return true;
        
        y = (int) (layers.square4.transform.position.y - 0.5f);
        x = (int) (layers.square4.transform.position.x - 0.5f);
        if (y == 0)
            return true;
        if (cases[y - 1][x] != null)
            return true;

        return false;
    }

    //Test if the current piece can go on its right (or left)
    bool blockSide(bool right)
    {
        int side = 1;
        if (!right)
            side = -1;
        Layers layers = currentObj.GetComponent<Layers>();
        int y = (int) (layers.square1.transform.position.y - 0.5f);
        int x = (int) (layers.square1.transform.position.x - 0.5f);
        if (right && x == 9)
            return true;
        else if (!right && x == 0)
            return true;
        if (cases[y][x + side] != null)
            return true;
        
        y = (int) (layers.square2.transform.position.y - 0.5f);
        x = (int) (layers.square2.transform.position.x - 0.5f);
        if (right && x == 9)
            return true;
        else if (!right && x == 0)
            return true;
        if (cases[y][x + side] != null)
            return true;
        
        y = (int) (layers.square3.transform.position.y - 0.5f);
        x = (int) (layers.square3.transform.position.x - 0.5f);
        if (right && x == 9)
            return true;
        else if (!right && x == 0)
            return true;
        if (cases[y][x + side] != null)
            return true;
        
        y = (int) (layers.square4.transform.position.y - 0.5f);
        x = (int) (layers.square4.transform.position.x - 0.5f);
        if (right && x == 9)
            return true;
        else if (!right && x == 0)
            return true;
        if (cases[y][x + side] != null)
            return true;

        return false;
    }

    //Call the DestroyLine function for every line that needs to be destroyed
    void CheckLine(Layers layers)
    {
        List<int> toDestroy = new List<int>();
        int y = (int) (layers.square1.transform.position.y - 0.5f);
        if (!toDestroy.Contains(y) && !cases[y].Contains(null))
            toDestroy.Add(y);
        
        y = (int) (layers.square2.transform.position.y - 0.5f);
        if (!toDestroy.Contains(y) && !cases[y].Contains(null))
            toDestroy.Add(y);
        
        y = (int) (layers.square3.transform.position.y - 0.5f);
        if (!toDestroy.Contains(y) && !cases[y].Contains(null))
            toDestroy.Add(y);
        
        y = (int) (layers.square4.transform.position.y - 0.5f);
        if (!toDestroy.Contains(y) && !cases[y].Contains(null))
            toDestroy.Add(y);
        
        toDestroy.Sort();

        if (toDestroy.Count != 0)
        {
            for (int i = toDestroy.Count-1; i >= 0; i--)
            {
                DestroyLine(toDestroy[i]);
            }

            score += 15 * toDestroy.Count;
        }
    }

    //Move the current piece down and if the piece can't go down the next piece is instanciate
    void Fall()
    {
        Layers layers = currentObj.GetComponent<Layers>();
        if (blockDown(layers))
        {
            
            
            //Debug.Log("pos y top square" + currentObj.GetComponent<Layers>().square1.transform.position.x);
            layers.Detach();
            AddCurrent(layers);
            CheckLine(layers);
            
            
            
            next.transform.SetPositionAndRotation(new Vector3(spawnPosX, spawnPosY, 0), new Quaternion());
            
            currentObj = next;
            if (!CanBePlaced(currentObj.GetComponent<Layers>()))
            {
                transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                CancelInvoke(nameof(Fall));
            }
            next = Instantiate(randObj(), new Vector3(nextX, nextY, 0), new Quaternion());
            return;
        }
        var tmp = currentObj.transform.position;
        currentObj.transform.SetPositionAndRotation(new Vector3(tmp.x, tmp.y-1, tmp.z), currentObj.transform.rotation);
    }


    //Move the current piece on its right (or left)
    void ChangeX(bool right)
    {
        var tmpP = currentObj.transform.position;
        var tmpR = currentObj.transform.rotation;
        Vector3 move;
        if (right)
        {/*
            if (currentObj.tag.Equals("Piece T"))
            {
                //if (currentObj.GetComponent<Layers>().getPhase() != )
            }*/
            if (blockSide(true) )
                return;
            move = new Vector3(tmpP.x + 1, tmpP.y, tmpP.z);
        }
        else
        {
            if (blockSide(false))
                return;
            move = new Vector3(tmpP.x - 1, tmpP.y, tmpP.z);
        }
        currentObj.transform.SetPositionAndRotation(move, tmpR);

    }

    
    void DirectFall()
    {
        var tmp = currentObj;
        while (tmp == currentObj)
            Fall();
    }

    //Make the current piece rotating if it has the possibility
    void TryRotate()
    {
        Layers layers = currentObj.GetComponent<Layers>();
        if (layers.newLeft() < 0 || layers.newRight() > 9)
            return;
        var list = layers.newSquares();
        for (int i = 0; i < list.Count; i++)
        {
            int y = (int) (list[i].transform.position.y - 0.5f);
            int x = (int) (list[i].transform.position.x - 0.5f);
            if (cases[y][x] != null)
                return;
        }
        layers.Rotate();
    }

    bool CanBePlaced(Layers layers)
    {
        int y = (int) (layers.square1.transform.position.y - 0.5f);
        int x = (int) (layers.square1.transform.position.x - 0.5f);
        if (cases[y][x] != null)
            return false;
        y = (int) (layers.square2.transform.position.y - 0.5f);
        x = (int) (layers.square2.transform.position.x - 0.5f);
        if (cases[y][x] != null)
            return false;
        y = (int) (layers.square3.transform.position.y - 0.5f);
        x = (int) (layers.square3.transform.position.x - 0.5f);
        if (cases[y][x] != null)
            return false;
        y = (int) (layers.square4.transform.position.y - 0.5f);
        x = (int) (layers.square4.transform.position.x - 0.5f);
        if (cases[y][x] != null)
            return false;
        return true;
    }
    
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            ChangeX(true);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            ChangeX(false);
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            TryRotate();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            Fall();
        else if (Input.GetKeyDown(KeyCode.Space))
            DirectFall();
    }
    
}
