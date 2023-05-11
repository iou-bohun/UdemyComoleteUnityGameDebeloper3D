using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] float period = 2f;
    [SerializeField] Vector3 movementVec; // �̵� �Ÿ� ����
    float movementFactor;

    private void Start()
    {
        startingPos = transform.position;
    }
    private void Update()
    {
        ObstacleMovement();
    }

    private void ObstacleMovement()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;// �ð��� ���� ��� ���� 
        const float tau = Mathf.PI * 2; // 6.238
        float rawSinWave = Mathf.Sin(cycles * tau); //going from -1 to 1 

        movementFactor = (rawSinWave + 1f) / 2; // recalculate to go from to 1 so its cleaner
        Vector3 offset = movementVec * movementFactor;
        transform.position = startingPos + offset;
    }
}
