using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankActions : MonoBehaviour
{

    public int movementSpeed = 0;
    public int rotationSpeedTank = 0;
    public int rotationSpeedTurret = 0;

    Transform tankBody;
    Transform tankTurret;
    Rigidbody2D rb2D;
    Transform barrelObject;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        tankBody = transform.Find("Chassie");
        tankTurret = transform.Find("Turret");
        barrelObject = tankTurret.transform.Find("Barrel");
    }

    public void MovePlayer(float inputValue)
    {
        rb2D.velocity = tankBody.right * inputValue * movementSpeed;
    }

    public void RotateTankBody(float inputValue)
    {
        float rotation = -inputValue * rotationSpeedTank;
        tankBody.Rotate(Vector3.forward * rotation);

    }

    public void RotateTankTurret(Vector3 endpoint)
    {
        Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, endpoint - tankTurret.position);
        desiredRotation = Quaternion.Euler(0, 0, desiredRotation.eulerAngles.z+90);
        tankTurret.rotation = Quaternion.RotateTowards(tankTurret.rotation, desiredRotation, rotationSpeedTurret * Time.deltaTime);

    }

    public void Shoot(GameObject bullet)
    {
        GameObject newBullet = Instantiate(bullet, barrelObject.position, tankTurret.transform.rotation);
    }
}
