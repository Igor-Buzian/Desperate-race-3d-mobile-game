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
        // �������� ���� �� ������
        movementInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        // ��������� ���� � Rigidbody ��� �������� ������
        carRigidbody.AddForce(transform.forward * speed * movementInput);

        // ��������� ������ � Rigidbody ��� �������� ������
        carRigidbody.AddTorque(transform.up * rotationSpeed * rotationInput);
    }
}
