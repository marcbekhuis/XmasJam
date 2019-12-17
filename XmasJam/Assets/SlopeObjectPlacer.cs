using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeObjectPlacer : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToPlace;
    [SerializeField] private int amountToPlace = 50;

    private List<Transform> placedObjects = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountToPlace; i++)
        {
            PlaceOnTerrain();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaceOnTerrain()
    {
        Vector3 position = new Vector3(0,0,0);
        bool goodLocationFound = false;
        while (!goodLocationFound)
        {
            goodLocationFound = FindGoodLocation(out position);
        }
        placedObjects.Add(Instantiate(objectsToPlace[Random.Range(0, objectsToPlace.Length)], position, new Quaternion(0,0,0,0)).transform);
    }

    private bool FindGoodLocation(out Vector3 Position)
    {
        Vector3 position = this.transform.position + this.transform.rotation * new Vector3(Random.Range(-80, 80), 0, Random.Range(-45, 45));
        foreach (var placedObject in placedObjects)
        {
            if (Vector3.Distance(placedObject.position, position) < 7)
            {
                Position = position;
                return false;
            }
        }
        Position = position;
        return true;
    }
}
