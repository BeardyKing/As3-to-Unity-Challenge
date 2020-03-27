using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTrail : MonoBehaviour
{
    [SerializeField] List<Vector3> lastPositions;
    LineRenderer lr;

    private void Awake(){
        lr = GetComponent<LineRenderer>();
    }

    void Update(){
        while (lastPositions.Count > 10){
            lastPositions.RemoveAt(0);
        }
        lastPositions.Add(transform.position);



        lr.positionCount = lastPositions.Count;
        lr.SetPositions(lastPositions.ToArray());
    }
}
