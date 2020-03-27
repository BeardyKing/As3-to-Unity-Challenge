using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericStoreHouse : MonoBehaviour {

    [Header("Amount of Resources")]
    [SerializeField] private int rawMaterial;
    [SerializeField] private int refinedMaterial;

    [Header("ResourceCap")]
    [SerializeField] private int maxRawMaterial;
    [SerializeField] private int maxRefinedMaterial;

    [SerializeField] List<GameObject> ResourceToCollect;
    [SerializeField] List<GameObject> currentWorkers;

    void AddRawResources(int amount){

    }

    int RequestRefinedResource(){
        return 0;
    }
}
