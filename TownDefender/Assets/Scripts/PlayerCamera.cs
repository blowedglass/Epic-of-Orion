using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private float distanceAway = 4f;
    private float distanceUp = 2f;
    private float smooth = 8f;
    private Transform follow;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        follow = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        targetPosition = follow.position + Vector3.up * distanceUp - follow.forward * distanceAway;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);
        transform.LookAt(follow);

        RaycastHit hit;
        Vector3 backward = transform.TransformDirection(Vector3.back);
        Debug.DrawRay(transform.position, backward, Color.green);

        if (Physics.Raycast(transform.position, (backward), out hit, 4))
        {
            distanceAway = hit.distance;
        }
        else
        {
            distanceAway = 4f;
        }

    }
}