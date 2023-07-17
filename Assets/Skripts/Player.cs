using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [Header("Wheels Colliders")]
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider backLeftWheelCollider;
    public WheelCollider backRightWheelCollider;

    [Header("Wheels Transform")]
    public Transform frontLeftWheelåTransform;
    public Transform frontRightWheelTransform;
    public Transform backLeftWheelTransform;
    public Transform backRightWheelTransform;

    [Header("Car Engine")]
    [SerializeField] public float accelerationForce = 300f;
    [SerializeField] private float BreakingForce = 3000f;
    private float presentBreakForce = 0f;
    private float presentAcceleration = 0f;

    [Header("car steering")]
    public float wheelsTorque = 35f;
    private float presentTurnAngle = 0f;

    //Ýëåìåíòû äëÿ âûâîäà ïîçèöèè èãðîêà
    [Header("Objects for car position")]
    public Transform playerTransform;
    public Transform[] opponentTransforms;
    public Text positionText;
    private int playerPosition = 1;

    private void Update()
    {
        CarPosition();
    }
    private void FixedUpdate()
    {
        MoveCar();
        CarSteering();
    }

    void CarPosition()
    {
        int opponentsAhead = 1;

        foreach (Transform opponentTransform in opponentTransforms)
        {
            Vector3 playerDirection = playerTransform.forward;
            Vector3 opponentDirection = opponentTransform.position - playerTransform.position;
            float dotProduct = Vector3.Dot(playerDirection.normalized, opponentDirection.normalized);

            if (dotProduct > 0f)
            {
                opponentsAhead++;
            }
        }

        // Îáíîâëÿåì ïîçèöèþ èãðîêà
        playerPosition = opponentsAhead;

        // Îáíîâëÿåì òåêñò â îáúåêòå Text
        positionText.text = $"Position:\r\n{playerPosition}/6";
    }

    private void OnTriggerEnter(Collider other)
    {
        // Åñëè èãðîê îáîãíàë äðóãîãî ãîíùèêà, òî ìåíÿåì èõ ìåñòàìè
        if (other.CompareTag("OpponentCar"))
        {
            Vector3 playerDirection = playerTransform.forward;
            Vector3 opponentDirection = other.transform.position - playerTransform.position;
            float dotProduct = Vector3.Dot(playerDirection.normalized, opponentDirection.normalized);

            if (dotProduct > 0f)
            {
                int opponentIndex = System.Array.IndexOf(opponentTransforms, other.transform);
                Transform tempTransform = opponentTransforms[opponentIndex];
                opponentTransforms[opponentIndex] = playerTransform;
                playerTransform = tempTransform;
            }
        }
    }
    private void MoveCar()
    {
        frontLeftWheelCollider.motorTorque = presentAcceleration;
        frontRightWheelCollider.motorTorque = presentAcceleration;
        backLeftWheelCollider.motorTorque = presentAcceleration;
        backRightWheelCollider.motorTorque = presentAcceleration;

        presentAcceleration = accelerationForce * SimpleInput.GetAxis("Vertical");
    }

    private void CarSteering()
    {
        presentTurnAngle = wheelsTorque * SimpleInput.GetAxis("Horizontal");
        frontLeftWheelCollider.steerAngle = presentTurnAngle;
        frontRightWheelCollider.steerAngle = presentTurnAngle;


        SteeringWheels(frontLeftWheelCollider, frontLeftWheelåTransform);
        SteeringWheels(frontRightWheelCollider, frontRightWheelTransform);
        SteeringWheels(backLeftWheelCollider, backLeftWheelTransform);
        SteeringWheels(backRightWheelCollider, backRightWheelTransform);
    }

     void SteeringWheels(WheelCollider WC, Transform WT)
    {
        Vector3 position;
        Quaternion rotation;

        WC.GetWorldPose(out position, out rotation);

        WT.position = position;
        WT.rotation = rotation;
    }

    public void ApplyBreaks()
    {

        StartCoroutine(CarBreaks());
    }
    IEnumerator CarBreaks()
    {
        presentBreakForce = BreakingForce;

        frontLeftWheelCollider.brakeTorque = presentBreakForce;
        frontRightWheelCollider.brakeTorque = presentBreakForce;
        backLeftWheelCollider.brakeTorque = presentBreakForce;
        backRightWheelCollider.brakeTorque = presentBreakForce;

        yield return new WaitForSeconds(2f);

        presentBreakForce = 0f;

        frontLeftWheelCollider.brakeTorque = presentBreakForce;
        frontRightWheelCollider.brakeTorque = presentBreakForce;
        backLeftWheelCollider.brakeTorque = presentBreakForce;
        backRightWheelCollider.brakeTorque = presentBreakForce;

    }
}
