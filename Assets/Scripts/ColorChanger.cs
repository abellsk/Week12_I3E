using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public MeshRenderer myRenderer;

    public Color anotherColor;

    private Color startColor;

    public float totalDuration; //is how many seconds irl, change in the inspector

    private float currentDuration;

    public float testFloat;

    //---------------------------------------------
    public Color[] newColors;

    private int colorIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        // myRenderer.material.color = newColor; //to choose from private newcolor
        startColor = myRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        // check whether current duration has met total duration
        // if it hasnt, run the code in the curly braces
        if (currentDuration < totalDuration) 
        {
            // get amount of time passed relative to the total duration
            float changePercent = currentDuration / totalDuration;

            Debug.Log(changePercent);

            // add time.deltaTime to currentDuration every frame
            currentDuration += Time.deltaTime;

            // use the lerp function to get a color between startcolor and anothercolor
            // pass in changePercent to set how far along the lerp to get a color from.
            /// myRenderer.material.color = Color.Lerp(startColor, anotherColor, changePercent);

            
            myRenderer.material.color = Color.Lerp(startColor, newColors[colorIndex], changePercent);
        }
        // else,, reset currentDuration and increase colorIndex;
        else
        {
            ++colorIndex;

            if (colorIndex >= newColors.Length)
            {
                colorIndex = 0;
            }

            currentDuration = 0f;
            startColor = myRenderer.material.color; //use this to reset.
        }
        

        //myRenderer.material.color = anotherColor; // can choose anything from inspector
        
    }
}
