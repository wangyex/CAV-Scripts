using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjectActivator1 : MonoBehaviour
{
    // Serialize this field to set it from the Unity inspector
    [SerializeField]
    private GameObject[] objectsToActivate; // Array of GameObjects to be deactivated

    // This method is called when another collider enters the trigger collider attached to the object this script is attached to
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);
        // Check if the colliding object has the tag 'Player'
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected, activating objects");
            // Deactivate all GameObjects in the array
            foreach (GameObject obj in objectsToActivate)
            {
                if (obj != null)
                    obj.SetActive(true);
            }
        }
    }
}
