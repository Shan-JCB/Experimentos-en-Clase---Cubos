using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerTarget;
    [Range(0, 180)]
    public float fieldOfViewAngle = 90f;

    private Material _material;
    private Color _originalColor;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
        _originalColor = _material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTarget == null) return;

        Vector3 directionToPlayer = (playerTarget.position - transform.position).normalized;
        float dotProduct = Vector3.Dot(transform.forward, directionToPlayer);
        float fovDotProductThreshold = Mathf.Cos(fieldOfViewAngle * 0.5f * Mathf.Deg2Rad);
        
        if(dotProduct >= fovDotProductThreshold)
        {
            _material.color = Color.red;
        }
        else
        {
            _material.color = _originalColor;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Quaternion leftRayRotation = Quaternion.AngleAxis(-fieldOfViewAngle * 0.5f, Vector3.up);
        Quaternion rightRayRotation = Quaternion.AngleAxis(fieldOfViewAngle * 0.5f, Vector3.up);
        Vector3 leftRayDirection = leftRayRotation * transform.forward;
        Vector3 rightRayDirection = rightRayRotation * transform.forward;
        Gizmos.DrawRay(transform.position, leftRayDirection * 5f);
        Gizmos.DrawRay(transform.position, rightRayDirection * 5f);
    }
}
