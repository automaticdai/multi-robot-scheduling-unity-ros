using UnityEngine;

public class agent : MonoBehaviour
{
    [SerializeField] private float minSpeed = 2f;
    [SerializeField] private float maxSpeed = 10f;

    private float moveSpeed;
    private float moveDirection;
    private Rigidbody rigidbodyComponent;

    // Start is called before the first frame update
    void Start() {
        rigidbodyComponent = GetComponent<Rigidbody>();
        moveSpeed = Random.Range(minSpeed, maxSpeed);
        moveDirection = Random.Range(-1.0f, 1.0f) * Mathf.PI;
    }

    private void FixedUpdate() {
        // Drive the horizontal plane only. The vertical component is left to the
        // solver, otherwise zeroing it every step cancels out gravity and the
        // robot never settles on the floor.
        Vector3 velocity = rigidbodyComponent.velocity;
        velocity.x = moveSpeed * Mathf.Sin(moveDirection);
        velocity.z = moveSpeed * Mathf.Cos(moveDirection);
        rigidbodyComponent.velocity = velocity;
    }

    private void OnCollisionEnter(Collision collision) {
        // Horizontal velocity is re-applied every step, so the solver's own
        // collision response would be thrown away on the next FixedUpdate.
        // Steer off the contact normal instead so collisions actually matter.
        if (collision.contactCount == 0) {
            return;
        }

        Vector3 normal = collision.GetContact(0).normal;
        normal.y = 0f;
        if (normal.sqrMagnitude < 0.0001f) {
            // Floor contact: nothing to steer around.
            return;
        }
        normal.Normalize();

        Vector3 heading = new Vector3(Mathf.Sin(moveDirection), 0f, Mathf.Cos(moveDirection));
        Vector3 reflected = Vector3.Reflect(heading, normal);
        if (reflected.sqrMagnitude > 0.0001f) {
            moveDirection = Mathf.Atan2(reflected.x, reflected.z);
        }
    }
}
