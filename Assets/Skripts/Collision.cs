using UnityEngine;

public class Collision : MonoBehaviour
{
  /*  public float pushForce = 10f; // �������� ���� ������������

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("OpponentCar")) // ��������, ��� ����������� � ��������� �����������
        {
            // ����������� ����������� ������������
            Vector3 pushDirection = transform.position - collision.transform.position;

            // ���������� ���� ������������ � ���������� ������
            Rigidbody playerCarRigidbody = GetComponent<Rigidbody>();
            playerCarRigidbody.AddForce(pushDirection.normalized * pushForce, ForceMode.Impulse);

            // ���������� ��������������� ���� ������������ � ���������� ����������
            Rigidbody enemyCarRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            enemyCarRigidbody.AddForce(-pushDirection.normalized * pushForce, ForceMode.Impulse);
        }
    }*/
}
