using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 10f;

    void Update()
    {
        // Liikkeen input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Liikettä vektori
        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized;

        if (movement.magnitude >= 0.1f)
        {
            // Lasketaan kulma mihin pelaaja kääntyy
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            float angle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, Time.deltaTime * turnSpeed);

            // Käännytään oikeaan suuntaan
            transform.rotation = Quaternion.Euler(0, angle, 0);

            // Liikutaan eteenpäin
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}