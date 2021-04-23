using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootBehaviour : MonoBehaviour
{
    [SerializeField]
    private BulletEmitterBehaviour _bulletEmitter;
    [SerializeField]
    private float _shotSpeed;
    [SerializeField]
    private float _range = 2;
    [SerializeField]
    private float _timePerShoot = 1;
    [SerializeField]
    public GameObject Target;
    private float _time = 0;
    // Update is called once per frame
    void Update()
    {
        if (!Target)
            return;
        //gets the direction the first target is in the list to the player
        Vector3 direction = Target.transform.position - transform.position;
        //set the distance from each object
        float distance = direction.magnitude;

        _time += Time.deltaTime;
        //if the player is in range to attack
        if (distance < _range && _bulletEmitter)
        {//look at the enemy
            transform.LookAt(Target.transform.position);
            //if the time is right
            if(_time > _timePerShoot)
            {//shoot the enemy
                _bulletEmitter.Fire(transform.forward * _shotSpeed);
                _time = 0;
            }
        }
    }
}
