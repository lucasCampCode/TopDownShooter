using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollowBehaviour : MonoBehaviour
{
    [Tooltip("target for the camera to follow")]
    [SerializeField]
    private GameObject _target;
    private Vector3 _offset;
    // Start is called before the first frame update
    void Start()
    {//sets the offset to the current camera position
        _offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //gets teh target position
        Vector3 targetPos = _target.transform.position;
        //sets teh camera new postition to be on the target with its offset
        transform.position = new Vector3(targetPos.x + _offset.x, targetPos.y + _offset.y, targetPos.z + _offset.z);
    }
}
