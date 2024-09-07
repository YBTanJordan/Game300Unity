using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickDrop : MonoBehaviour
{
    public List<GameObject> PickUpPoints;
    public List<GameObject> DropOffPoints;

    private GameObject currPoint;
    private bool isPickingUp;

    // Start is called before the first frame update
    void Start()
    {
        // Deactivate all pickup and drop-off points initially
        foreach (GameObject point in PickUpPoints)
        {
            point.SetActive(false);
        }

        foreach (GameObject point in DropOffPoints)
        {
            point.SetActive(false);
        }

        // Randomly select a pickup point and activate it
        isPickingUp = true;
        currPoint = PickUpPoints[Random.Range(0, PickUpPoints.Count)];
        currPoint.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.gameObject == currPoint)
        {
            // Deactivate the current point
            currPoint.SetActive(false);
            isPickingUp = !isPickingUp;
            
            if (isPickingUp)
            {
                currPoint = PickUpPoints[Random.Range(0, PickUpPoints.Count)];
            }
            else
            {
                currPoint = DropOffPoints[Random.Range(0, DropOffPoints.Count)];
            }
            
            currPoint.SetActive(true);
        }
    }
}
