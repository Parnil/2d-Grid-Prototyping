using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    public int height;                                  //Height of the game board
    public int width;                                   //Width of the game board
    public static BoardManager instance = null;         //Static instance of the BoardManager to be accessed by other scripts

    public GameObject Tile;

	// Use this for initialization
	void Awake ()
    {
        //Check if instance already exists
        //If not set instance to this
        if (instance == null)
            instance = this;

        //If it exists but is another instance destroy it to enforce our singleton pattern
        else if (instance != this)
            Destroy(gameObject);

        //Set this to not be destroyed when reloading a scene
        //DontDestroyOnLoad(gameObject);

        //Call the board initialisation method
        InitBoard();
	}

    void InitBoard()
    {

        //Create a Tile prefab on each cell of our board
        //And set its parent to the Board game object
        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                Vector3 tilePos = new Vector3(x, y, 0);
                GameObject instance = Instantiate(Tile, tilePos, Quaternion.identity) as GameObject;
                instance.transform.SetParent(gameObject.transform);
            }
        }
    }
}
