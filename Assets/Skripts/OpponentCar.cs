using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCar : MonoBehaviour
{
    [Header("Car Engine")]
    public float movingSpeed;
    public float turningSpeed = 50f;
    public float breakSpeed = 12f;

    [Header("Destonation Var")]
    public Vector3 destination;
    public bool destinationReached;

    [Header("Shift Object")]
    public float forceAmount = 12f;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Drive();
    }

    public void Drive()
    {

        if (transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;
            float destinationDistance = destinationDirection.magnitude;

            if (destinationDistance >= breakSpeed)
            {
                destinationReached = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turningSpeed * Time.deltaTime);

                //Move Vehicle
                transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);
            }
            else
            {
                destinationReached = true;
            }
        }
    }

    public void LocalDestination(Vector3 destination)
    {
        this.destination = destination;
        destinationReached = false;
    }
  /*  void OnTriggerEnter(Collider other)
    {
        // Проверяем, что столкнулись с другой машиной
        if (other.CompareTag("Player") || other.CompareTag("OpponentCar"))
        {
            // Вычисляем направление, в котором нужно отклонить машину
            Vector3 dir = (transform.position - other.transform.position).normalized;

            // Применяем силу к Rigidbody вражеской машины в направлении, противоположном направлению столкновения
            rb.AddForce(dir * forceAmount, ForceMode.Impulse);
        }
    }*/
}
