using UnityEngine;

public class Collision : MonoBehaviour
{
  /*  public float pushForce = 10f; // Параметр силы отталкивания

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("OpponentCar")) // Проверка, что столкнулись с вражеским автомобилем
        {
            // Определение направления отталкивания
            Vector3 pushDirection = transform.position - collision.transform.position;

            // Применение силы отталкивания к автомобилю игрока
            Rigidbody playerCarRigidbody = GetComponent<Rigidbody>();
            playerCarRigidbody.AddForce(pushDirection.normalized * pushForce, ForceMode.Impulse);

            // Применение противоположной силы отталкивания к вражескому автомобилю
            Rigidbody enemyCarRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            enemyCarRigidbody.AddForce(-pushDirection.normalized * pushForce, ForceMode.Impulse);
        }
    }*/
}
