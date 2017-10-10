using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    public Transform tileSelector;              //Get a reference to our Tile Selector

    private Vector3 mousePos;                   //A Vector 3 variable that holds the position of the mouse converted to  rounded world space
    private bool tileSelected = false;          //This variable is used to determine whether a tile is currently selected

    void Update ()
    {
        moveTileSelector();
	}

    void moveTileSelector()
    {
        //If the player presses the left mouse button select the tile
        if (Input.GetMouseButtonDown(0))
        {
            selectTile();
        }

        //If the player presses the escape key deselect the tile
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            deselectTile();
        }

        //If a Tile is selected exit out of the code
        if (tileSelected)
        return;

        //Get the Position of the mouse cursor in screen space and convert it to world space
        //The Z value of the mouse position will be the Z value of our camera
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        mousePos = new Vector3(Mathf.RoundToInt(mousePos.x), Mathf.RoundToInt(mousePos.y), Mathf.RoundToInt(mousePos.z));

        //Change the position of the tile selector while keeping it "inside" the board
        //The board is currently set to be 10x10 hence the hardcoding of the maximum values for x and y
        if ((mousePos.x >= 0 && mousePos.x < BoardManager.instance.height) && (mousePos.y >= 0 && mousePos.y < BoardManager.instance.width))
        {
            tileSelector.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    //Do tile selection activities here, e.g unit selection, maybe show on the grid where the unit can move etc
    void selectTile()
    {
        tileSelected = true;
    }

    //Deselect tile
    void deselectTile()
    {
        tileSelected = false;
    }
}
