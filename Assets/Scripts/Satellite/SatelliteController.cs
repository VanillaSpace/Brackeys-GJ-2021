using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteController : MonoBehaviour {

    public Transform[] AlienDoodsPositions;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("SATELLITE CONTACTED");
            PlaceAlienDood();
        }
    }

    void PlaceAlienDood() {
        GameManager GM = GameManager.instance;
        if(GM.canPickMore()) {
            int currentDoods = GM.currentDoods;
            int doodIndex = currentDoods; --doodIndex;
            string doodName = "Alien_" + currentDoods;
            GameObject AlienDood = GM.AlienDoodHoldPosition.Find(doodName).gameObject;
            AlienDood.transform.position = AlienDoodsPositions[doodIndex].position;
            AlienDood.transform.parent = null;
            AlienDood.transform.parent = AlienDoodsPositions[doodIndex];
            GM.isPlayerCarryingDood = false;
            GM.updateSignalProgress(AlienDood.GetComponent<AlienDood>().powerValue);
        }
    }
    
    void Start() { }

    void Update() { }
}