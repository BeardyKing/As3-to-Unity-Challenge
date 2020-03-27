using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    [SerializeField] GameObject windPrefab;

    [SerializeField] Camera cam;
    [SerializeField] Transform hitSpawnPosition;
    [SerializeField] Transform hitHoldPosition;

    [SerializeField] List<GameObject> windSpawned;

    float windSpawnTimer;
    [SerializeField] float windSpawnReset = .03f;

    [SerializeField] bool mouseBeingHeld;

 
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            SetSpawnPosition();
        }

        if (Input.GetMouseButtonUp(0)){
            ShootWindInList();
            mouseBeingHeld = false;
        }

        if (mouseBeingHeld){
            SetHoldPosition();
            SpawnWind();
        }

    }

    int windForce = 20;

    void ShootWindInList(){
        if (windSpawned.Count > 0){
            float distance = (hitSpawnPosition.position - hitHoldPosition.position).magnitude;
            for (int i = 0; i < windSpawned.Count; i++){
                Vector3 rnd = Random.insideUnitSphere / 5;
                if (distance <= windForce){
                    windSpawned[i].GetComponent<Rigidbody>().velocity = ((hitSpawnPosition.position - hitHoldPosition.position).normalized + rnd) * distance;
                }
                else{
                    windSpawned[i].GetComponent<Rigidbody>().velocity = ((hitSpawnPosition.position - hitHoldPosition.position).normalized + rnd) * windForce;
                }
                Destroy(windSpawned[i], Random.Range(9f,11f));
            }
            Debug.Log(distance);
            windSpawned.Clear();
        }
    }

    void SpawnWind(){
        windSpawnTimer -= Time.deltaTime;
        if (windSpawnTimer <= 0){
            windSpawnTimer = windSpawnReset;

            GameObject temp = Instantiate(windPrefab);
            temp.transform.position = hitSpawnPosition.position + (Vector3.up * 3) + (Random.insideUnitSphere * 1.3f) + (-(hitSpawnPosition.position - hitHoldPosition.position).normalized * 1.4f);
            windSpawned.Add(temp);
        }
    }


    void SetSpawnPosition(){
        windSpawnTimer = windSpawnReset;
        mouseBeingHeld = true;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)){
            hitSpawnPosition.position = hit.point;
        }
        
    }


    void SetHoldPosition(){
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)){
            hitHoldPosition.position = hit.point;
        }
    }

}
