using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int      numBaskets = 4;
    public float    basketBottomY = -14f;
    public float    basketSpacingY = -2f;
    public List<GameObject> basketList;
    public RoundCounter roundCounter;
    
    // Start is called before the first frame update
    void Start()
    {

        basketList = new List<GameObject>();

        // round counter 
        // find the roundcounter gameobject in the scene hierarchy
        GameObject roundGO = GameObject.Find("RoundCounter");
        // Get the roundcounter script component of roundGO
        roundCounter = roundGO.GetComponent<RoundCounter>();
        roundCounter.round = numBaskets - (numBaskets-1);   

        for (int i=0; i <numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }
    
    public void AppleMissed()
    {
        // destroy all of the falling apples
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }

        // destroy one of the baskets
        // get the index of the last basket in the basketlist
        int basketIndex = basketList.Count -1;
        // get a reference to that basket gameobject
        GameObject basketGO = basketList[basketIndex];
        // remove basket from the list and destroy the gameobject
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);
        roundCounter.round += 1;

        // if no more baskets left, restart the game
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }
}
