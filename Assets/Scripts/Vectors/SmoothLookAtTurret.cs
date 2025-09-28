using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothLookAtTurret : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    [Range(0.1f, 10f)]
    public float rotationSpeed = 5f;

    // Update is called once per frame
    private void Update()
    {
        if (target == null) return;
        Vector3 directionToTarget = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
