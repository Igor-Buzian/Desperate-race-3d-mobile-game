using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 100f;

    private float movementInput;
    private float rotationInput;
    private Rigidbody carRigidbody;

    private void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Получаем ввод от игрока
        movementInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        // Применяем силу к Rigidbody для движения машины
        carRigidbody.AddForce(transform.forward * speed * movementInput);

        // Применяем момент к Rigidbody для поворота машины
        carRigidbody.AddTorque(transform.up * rotationSpeed * rotationInput);
    }
}
