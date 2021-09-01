using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public int id = -1;
    public LevelManager manager;

    public bool mouseOver = false; 

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        mouseOver = true;
        animator.SetBool("Mouse Over", true);
    }

    private void OnMouseExit()
    {
        mouseOver = false;
        animator.SetBool("Mouse Over", false);
    }

    public void HasBeenSelected(bool selected) { //equivalent de SetActive, ne pas devoir faire 2 fois le code
        animator.SetBool("Item Selected", selected);
        

    }

    public void HasBeenMatched() { //pas de paramètres pcq c'est toujours true
    animator.SetBool("Item Match",true);

    }
}