using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestTargetBehaviour : MonoBehaviour
{
    [Tooltip("list of targets in the scene")]
    [SerializeField]
    public List<GameObject> Targets;
    [SerializeField]
    private PlayerShootBehaviour _shootBehaviour;
    [SerializeField]
    private GameObject _player;

    private void Update()
    {
        //grabs the first target claims it to be closest
        GameObject closest = Targets[0];
        //loop throught the entire array of targets
        for(int i = 0; i < Targets.Count; i++)
        {
            //removes the targets that been destroy
            if(Targets[i]== null)
            {
                Targets.RemoveAt(i);
            }
            //gets the distance of the closest target at the moment
            float closestDist = (closest.transform.position - _player.transform.position).magnitude;
            //gets teh distance of the current target in the loop
            float currentDist = (Targets[i].transform.position - _player.transform.position).magnitude;
            // if the closest is further than the current target in the loop
            if (closestDist > currentDist)
            {//set the new closest to be the current target
                closest = Targets[i];
            }   
            
        }//loop ends
        //sets the shootBehaviour target to be the closest
        _shootBehaviour.Target = closest;
        
    }
}
