using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public int row = 3;
    public int column = 4;
    public float gapRow = 1.5f;
    public float gapColumn = 1.5f;
    [Range(0f, 5f)]
    public float timeBeforeReset = 1f;
    private bool resetOngoing = false;
    public GameObject itemPrefab;
    public Material[] materials;
    public Material defaultMaterial;
    public ItemBehavior[] items;

    public List<int> selected = new List<int>();
    public List<int> matches = new List<int>();
    private Dictionary <int, Material> itemMaterial = new Dictionary<int, Material>();
    public UnityEvent whenPlayerWins;
    
    
    void Start()
    {
        items = new ItemBehavior[row * column];
        int index = 0;

        for(int x=0; x < column; x++){
            for (int z=0; z < row; z++){
                Vector3 position = new Vector3(x * gapColumn, 0, z * gapRow);
                GameObject item = Instantiate(itemPrefab, position, Quaternion.identity);
                item.GetComponent<Renderer>().material = defaultMaterial;

                items[index] = item.GetComponent<ItemBehavior>();

                items[index].id = index;
                items[index].manager = this;
                index++;

            }

        }
        GiveMaterials();

    }
    private void GiveMaterials() {
        List<int> possibilities = new List<int>();
        for(int i=0; i<row * column; i++){
            possibilities.Add(i);
        }

        for(int i=0; i < materials.Length; i++) {
            if(possibilities.Count < 2) break;

            int idPoss = Random.Range(0, possibilities.Count);
            int id1 = possibilities[idPoss];
            possibilities.RemoveAt(idPoss);

            idPoss = Random.Range(0, possibilities.Count);
            int id2 = possibilities[idPoss];
            possibilities.RemoveAt(idPoss);

            itemMaterial.Add(id1, materials[i]);
            itemMaterial.Add(id2, materials[i]);
            
        }
    }

    private IEnumerator ResetMaterials(int id1, int id2) {
        resetOngoing = true;
        yield return new WaitForSeconds(timeBeforeReset);
        ResetMaterial(id1);
        ResetMaterial(id2);
        resetOngoing = false;
    }

    private IEnumerator Win() {
        yield return new WaitForSeconds(timeBeforeReset);
        whenPlayerWins?.Invoke();
    }

    public void RevealMaterial(int id) {
        if (selected.Count < 2 && !selected.Contains(id) && resetOngoing == false && !matches.Contains(id)) {
            selected.Add(id);
            Material material = itemMaterial[id];
            items[id].GetComponent<Renderer>().material = material;
            items[id].HasBeenSelected(true);
        }
    }
    
    private void ResetMaterial(int id) {
        items[id].GetComponent<Renderer>().material = defaultMaterial;
        items[id].HasBeenSelected(false);
    }
    void Update()
    {
        if (selected.Count == 2) {
            if (itemMaterial[selected[0]] == itemMaterial[selected[1]]) {
                matches.Add(selected[0]);
                matches.Add(selected[1]);
                items[selected[0]].HasBeenMatched();
                items[selected[1]].HasBeenMatched();

                if(matches.Count >= row * column){
                    StartCoroutine(Win());
                }
            }
            else {
                StartCoroutine(ResetMaterials(selected[0], selected[1]));
                // items[selected[0]].HasBeenSelected(false);
                // items[selected[1]].HasBeenSelected(false);
            }
            selected.Clear();
        }
    }
}