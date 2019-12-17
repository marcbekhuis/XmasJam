using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePlacer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private int tilesToPlace = 6;
    [SerializeField] private GameObject tile;
    [SerializeField][Range(-90,90)] private float mountainSlope = -15;

    [SerializeField] private List<GameObject> tiles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < tilesToPlace; i++)
        {
            PlaceTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tiles.Count >= 2)
        {
            if (player.transform.position.z - tiles[1].transform.position.z < 10)
            {
                Destroy(tiles[0]);
                tiles.RemoveAt(0);
                PlaceTile();
            }
        }
    }

    private void PlaceTile()
    {
        tiles.Add(Instantiate(tile, tiles[tiles.Count - 1].transform.position - tiles[tiles.Count - 1].transform.rotation * new Vector3(0,0,100), new Quaternion(0,0,0,0)));
        tiles[tiles.Count - 1].transform.eulerAngles = new Vector3(mountainSlope,0,0);
    }
}
