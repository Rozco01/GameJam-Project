using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public Transform[] wheels;
    public float rotationSpeed = 100f;
    public bool[] spinning;
    private bool[] stopped;
    private int[] wheelNumbers;
    public GameObject RouletteMiniGame;
    public GameObject attackButton;
    [SerializeField] private LifeController lifeController;
    private bool shieldBroken = false;

    private int currentWheelIndex = 0;

    void Start()
    {
        attackButton.SetActive(true);
        RouletteMiniGame.SetActive(false);
        spinning = new bool[wheels.Length];
        stopped = new bool[wheels.Length];
        wheelNumbers = new int[wheels.Length];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Detener la rueda actual cuando se presiona la tecla de espacio
            StopSpin(currentWheelIndex);
            currentWheelIndex++;

            // Verificar si se alcanzó el final de las ruedas y reiniciar
            if (currentWheelIndex >= wheels.Length)
            {
                currentWheelIndex = 0;
            }
        }

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

        // Restaurar visualmente el escudo al inicio del giro
        lifeController.RestoreVisualShield();
        attackButton.SetActive(false);
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

            // Check if the shield is broken
            if (lifeController.IsShieldBroken())
            {
                // Restore the shield
                lifeController.RestoreShield();
                shieldBroken = false;
            }

            // Save the number where the wheel stopped
            wheelNumbers[index] = number;

            // Check if all wheels have stopped
            if (AllWheelsStopped())
            {
                int sum = CalculateSumOfWheelNumbers();
                float lifeLost = (float)sum;

                lifeController.ChangeLife(lifeLost);
                Debug.Log($"The sum of the numbers on the wheels is: {sum}");

                // Reset shieldBroken for the next turn
                shieldBroken = false;
            }
        }
    }

    // Método para indicar que el escudo se ha roto
    public void BreakShield()
    {
        shieldBroken = true;
        attackButton.SetActive(true);
    }

    int DetermineNumber(float angle)
    {
        float normalizedAngle = (angle + 360) % 360; // Normalizar el ángulo a un rango positivo

        // Utilizar rangos para manejar casos
        if (normalizedAngle >= 0 && normalizedAngle < 35)
        {
            return 25; // Azul, número 25
        }
        else if (normalizedAngle >= 35 && normalizedAngle < 125)
        {
            return 20; // Verde, número 20
        }
        else if (normalizedAngle >= 125 && normalizedAngle < 235)
        {
            return 15; // Amarillo, número 15
        }
        else if (normalizedAngle >= 235 && normalizedAngle < 360)
        {
            return 0; // rojo, número 0
        }

        return -1; // Valor predeterminado si no se cumple ninguna condición
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
