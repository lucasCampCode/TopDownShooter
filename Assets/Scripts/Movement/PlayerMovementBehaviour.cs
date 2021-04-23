using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [Tooltip("How fast the player will move.")]
    [SerializeField]
    private float _moveSpeed;
    [Tooltip("The current active camera. Used to get mouse position for rotation.")]
    [SerializeField]
    private Camera _camera;
    private Rigidbody _rigidbody;
    private NavMeshAgent _agent;
    private PlayerMeleeBehaviour _meleeBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        //Store reference to the attached rigidbody
        _rigidbody = GetComponent<Rigidbody>();
        //stores refrence to the attached NevMeshAgent
        _agent = GetComponent<NavMeshAgent>();
        //stores refrence to the attached PlayerMeleeBehaviour
        _meleeBehaviour = GetComponent<PlayerMeleeBehaviour>();
    }

    private void FixedUpdate()
    {
        //Create a ray that starts at a screen point
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        //Checks to see if the ray hits any object in the world
        if (Physics.Raycast(ray, out hit))
        {
            //Find the direction the player should move towards
            Vector3 moveDir = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            //when the primary button is down
            if (Input.GetMouseButton(0))
            {//set the player next stop
                _agent.SetDestination(moveDir);
                //if the clicked on an enemy
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {//and melee is selected
                    if(_meleeBehaviour.enabled)
                        //attack clicked object
                        _meleeBehaviour.attack(hit.collider.gameObject);
                }
            }
        }
    }
}
