using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{
    public int      round;
    private Text    roundText;

    // Start is called before the first frame update
    void Start()
    {
        roundText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        roundText.text = round.ToString("Round ,0");
    }
}
