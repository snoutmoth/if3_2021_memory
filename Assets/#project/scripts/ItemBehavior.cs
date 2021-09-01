using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public int id = -1;
    public LevelManager manager;

    public bool mouseOver = false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && mouseOver)
        {
            manager.RevealMaterial(id);
            
        }
    }

    void OnMouseOver()
    {
        transform.localScale = new Vector3(1, 2, 1);
        mouseOver = true;
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(1, 1, 1);
        mouseOver = false;
    }

}