using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float pullForce = 10f;
    public float pullRadius = 5f; // Set the radius within which the pull force is applied

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && other.attachedRigidbody)
        {
            Vector3 direction = transform.position - other.transform.position;
            float distance = direction.magnitude;
            float distanceRatio = Mathf.Clamp01((pullRadius - distance) / pullRadius); // Calculate the distance ratio

            // Apply the force more strongly when the ball is closer to the black hole
            other.attachedRigidbody.AddForce(direction.normalized * pullForce * distanceRatio * Time.deltaTime);
        }
    }
}
