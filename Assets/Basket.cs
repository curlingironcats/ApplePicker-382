using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;

    // Start is called before the first frame update
    void Start()
    {
        // find the scorecounter gameobject in the scene hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Get the scorecounter script component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();   
    }

    // Update is called once per frame
    void Update()
    {
     // get current position of mouse on screen from input
     Vector3 mousePos2D = Input.mousePosition;

     // the camera's z position sets how far to push the mouse into 3d
     // if this line causes a nullreferenceexception, select main camera
     // in the hierarchy and set its tag to maincamera in the inspector
     mousePos2D.z = -Camera.main.transform.position.z;

     // convert the point from 2d into 3d
     Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

     // move the x position of the basket to the x position of the mouse
     Vector3 pos = this.transform.position;
     pos.x = mousePos3D.x;
     this.transform.position = pos;   
    }

    void OnCollisionEnter(Collision coll)
    {
        // find out what hit the basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);

            // increase score
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
        else if (collidedWith.CompareTag("Branch"))
        {
            SceneManager.LoadScene("_Game_Over_Screen");
        }
    }
}
