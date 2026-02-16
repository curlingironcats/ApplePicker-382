using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{
    public int      round;
    public ApplePicker scriptAReference;
    private Text    roundText;

    // Start is called before the first frame update
    void Start()
    {
        roundText = GetComponent<Text>();
        
        ApplePicker ap = FindObjectOfType<ApplePicker>();
        scriptAReference = ap;
    }

    // Update is called once per frame
    void Update()
    {
        int roundOut = scriptAReference.numBaskets;
        roundText.text = round.ToString("Round: , 0/") + roundOut;
    }
}
