﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeObjectPlacer : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToPlace;
    [SerializeField] private GameObject[] cashToPlace;
    [SerializeField] private GameObject[] rocksToPlace;
    [SerializeField] private int amountToPlace = 50;
    [SerializeField] private int amountOfCashToPlace = 50;
    [SerializeField] private int amountOfRockToPlace = 50;
    [SerializeField] private float minDistanceBetweenObjects = 7;
    [SerializeField] private float xPlacementRange = 80;
    [SerializeField] private float zPlacementRange = 45;

    private List<Transform> placedObjects = new List<Transform>();
    private List<Transform> placedCash = new List<Transform>();
    private List<Transform> placedRocks = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountToPlace; i++)
        {
            PlaceOnTerrain();
        }
        for (int i = 0; i < amountOfCashToPlace; i++)
        {
            PlaceCashOnTerrain();
        }
        for (int i = 0; i < amountOfRockToPlace; i++)
        {
            PlaceRockOnTerrain(i);
        }
    }
    
    //TREES
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
        Vector3 position = this.transform.position + this.transform.rotation * new Vector3(Random.Range(-xPlacementRange, xPlacementRange), 0, Random.Range(-zPlacementRange, zPlacementRange));
        foreach (var placedObject in placedObjects)
        {
            if (Vector3.Distance(placedObject.position, position) < minDistanceBetweenObjects)
            {
                Position = position;
                return false;
            }
        }
        Position = position;
        return true;
    }

    private void OnDestroy()
    {
        while (placedObjects.Count != 0)
        {
            Destroy(placedObjects[0].gameObject);
            placedObjects.RemoveAt(0);
        }
        while (placedCash.Count != 0)
        {
            Destroy(placedCash[0].gameObject);
            placedCash.RemoveAt(0);
        }
        while (placedRocks.Count != 0)
        {
            Destroy(placedRocks[0].gameObject);
            placedRocks.RemoveAt(0);
        }
    }

    // CASH
    private void PlaceCashOnTerrain()
    {
        Vector3 position = new Vector3(0, 0, 0);
        bool goodLocationFound = false;
        while (!goodLocationFound)
        {
            goodLocationFound = FindGoodCashLocation(out position);
        }
        placedCash.Add(Instantiate(cashToPlace[Random.Range(0, cashToPlace.Length)], position + new Vector3(0,1,0), new Quaternion(0, 0, 0, 0)).transform);
    }

    private bool FindGoodCashLocation(out Vector3 Position)
    {
        Vector3 position = this.transform.position + this.transform.rotation * new Vector3(Random.Range(-xPlacementRange, xPlacementRange), 0, Random.Range(-zPlacementRange, zPlacementRange));
        foreach (var placedObject in placedObjects)
        {
            if (Vector3.Distance(placedObject.position, position) < minDistanceBetweenObjects / 2)
            {
                Position = position;
                return false;
            }
        }
        foreach (var placedCash in placedCash)
        {
            if (Vector3.Distance(placedCash.position, position) < minDistanceBetweenObjects)
            {
                Position = position;
                return false;
            }
        }
        Position = position;
        return true;
    }

    private void PlaceRockOnTerrain(int i)
    {
        Vector3 position = this.transform.position + this.transform.rotation * new Vector3(xPlacementRange, 0, -zPlacementRange + 10 * i);
        placedRocks.Add(Instantiate(rocksToPlace[Random.Range(0, rocksToPlace.Length)], position, new Quaternion(0, 0, 0, 0)).transform);
        placedRocks[placedRocks.Count - 1].localScale = new Vector3(Random.Range(4,20),Random.Range(10,40),Random.Range(10,30));
        position = this.transform.position + this.transform.rotation * new Vector3(-xPlacementRange, 0, -zPlacementRange + 10 * i);
        placedRocks.Add(Instantiate(rocksToPlace[Random.Range(0, rocksToPlace.Length)], position, new Quaternion(0, 0, 0, 0)).transform);
        placedRocks[placedRocks.Count - 1].localScale = new Vector3(Random.Range(4, 20), Random.Range(10, 40), Random.Range(10, 30));
    }
}
