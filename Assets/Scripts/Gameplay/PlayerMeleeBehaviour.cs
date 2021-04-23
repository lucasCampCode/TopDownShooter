using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeBehaviour : MonoBehaviour
{
    [Tooltip("how much damage the melee attack will do")]
    [SerializeField]
    private float _damage = 3;
    private void Start()
    {
        enabled = false;
    }
    public void attack(GameObject Target)
    {
        //get the players position
        Vector3 pos = transform.position;
        //set its x and z position to be half the distance of the player and the target
        pos.x = Mathf.Lerp(transform.position.x, Target.transform.position.x, 0.5f);
        pos.z = Mathf.Lerp(transform.position.z, Target.transform.position.z, 0.5f);
        //set player new position
        transform.position = pos;
        //deal damage to target
        Target.GetComponent<HealthBehaviour>().TakeDamage(_damage);
    }
}
