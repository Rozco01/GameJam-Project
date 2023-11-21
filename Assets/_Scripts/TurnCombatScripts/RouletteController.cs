using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public Transform[] wheels;
    public float rotationSpeed = 100f;
    public bool[] spinning;
    private bool[] stopped;
    private int[] wheelNumbers;
    public GameObject RouletteMiniGame;

    [SerializeField] private LifeController lifeController;

    void Start()
    {
        RouletteMiniGame.SetActive(false);
        spinning = new bool[wheels.Length];
        stopped = new bool[wheels.Length];
        wheelNumbers = new int[wheels.Length];
    }

    void Update()
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            if (spinning[i] && !stopped[i])
            {
                // Rotate the wheel in the desired direction
                wheels[i].Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            }
        }
    }

    public void StartSpin(int index)
    {
        RouletteMiniGame.SetActive(true);
        spinning[index] = true;
        stopped[index] = false;
    }

    public void StopSpin(int index)
    {
        if (spinning[index] && !stopped[index])
        {
            spinning[index] = false;

            // Calculate the current rotation of the wheel in degrees
            float currentAngle = wheels[index].eulerAngles.z % 360;

            // Set the rotation of the wheel to the current position
            wheels[index].rotation = Quaternion.Euler(0, 0, currentAngle);

            // Determine the number where the wheel stopped
            int number = DetermineNumber(currentAngle);

            Debug.Log($"Wheel {index} stopped at number: {number}");

            // Mark the wheel as stopped to prevent the message from being shown again
            stopped[index] = true;

            // Save the number where the wheel stopped
            wheelNumbers[index] = number;

            // Check if all wheels have stopped
            if (AllWheelsStopped())
            {
                float totalLife = 100;
                
                int sum = CalculateSumOfWheelNumbers();
                float lifeLost = (float)sum;

                lifeController.ChangeLife(totalLife - lifeLost);
                Debug.Log($"The sum of the numbers on the wheels is: {sum}");
            }
        }
    }

    int DetermineNumber(float angle)
    {
        // You can use ranges to handle cases
        if (angle >= 0 && angle < 90)
        {
            return 10; // Red, number 10
        }
        else if (angle >= 90 && angle < 180)
        {
            return 7; // Green, number 7
        }
        else if (angle >= 180 && angle < 270)
        {
            return 5; // Yellow, number 5
        }
        else if (angle >= 270 && angle < 360)
        {
            return 0; // Blue, number 0
        }

        return -1; // Default value if no condition is met
    }

    bool AllWheelsStopped()
    {
        // Check if all wheels have stopped
        for (int i = 0; i < stopped.Length; i++)
        {
            if (!stopped[i])
            {
                return false;
            }
        }
        return true;
    }

    int CalculateSumOfWheelNumbers()
    {
        // Sum the numbers where the wheels stopped
        int sum = 0;
        for (int i = 0; i < wheelNumbers.Length; i++)
        {
            sum += wheelNumbers[i];
        }
        return sum;
    }
}
