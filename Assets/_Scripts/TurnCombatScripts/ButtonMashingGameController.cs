using UnityEngine;
using UnityEngine.UI;

public class ButtonMashingGameController : MonoBehaviour
{
    public Slider progressBar;
    public float intensity = 3f; // Intensidad de descenso de la barra (ajustable en el inspector)
    public float countdownTime = 10.0f; // Tiempo para alcanzar el rango objetivo
    public float targetRange = 85; // Rango objetivo para ganar un punto
    public int winPoints = 1; // Puntos ganados al llegar al rango objetivo
    public TMPro.TextMeshProUGUI countdownText;
    public GameObject atackButton;
    public GameObject RouletteMiniGame;
    private int buttonPressCount = 0;
    private float currentProgressBarValue;
    [SerializeField] private GameObject miniGameObject;
    private bool gameActive = false;

    void Start()
    {
        
        ResetGame();
    }

    void Update()
    {
        if (gameActive)
        {
            // Actualizar el texto del contador
            countdownText.text = "Tiempo restante: " + Mathf.Round(countdownTime).ToString();

            // Verificar si el contador llegó a cero
            if (currentProgressBarValue < targetRange && countdownTime <= 0)
            {
                Debug.Log("¡Juego perdido! No has alcanzado el rango objetivo.");
                gameActive = false; // Detener el juego
                miniGameObject.SetActive(false); // Desactivar el minijuego
                atackButton.SetActive(true); // Activar el botón de ataque

            }
            else
            {
                // Descenso gradual de la barra con base en la intensidad
                currentProgressBarValue = currentProgressBarValue - (intensity * Time.deltaTime);
                progressBar.value = currentProgressBarValue;

                // Verificar si se alcanzó el rango objetivo
                if (currentProgressBarValue >= targetRange && countdownTime <= 0)
                {
                    Debug.Log("¡Has ganado un punto!");
                    gameActive = false; // Detener el juego
                    miniGameObject.SetActive(false); // Desactivar el minijuego
                    atackButton.SetActive(true); // Activar el botón de ataque
                }
            }

            // Actualizar el contador de tiempo
            countdownTime -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ButtonPressed();
        }
    }

    public void StartButtonMashingGame()
    {
        gameActive = true;
        RouletteMiniGame.SetActive(false);
        ResetGame();
    }

    public void ButtonPressed()
    {
        if (gameActive)
        {
            // Incrementar el contador de pulsaciones y actualizar la barra
            buttonPressCount++;
            currentProgressBarValue = Mathf.Clamp(currentProgressBarValue + 10, 0, 100);
        }
    }

    void ResetGame()
    {
        // Reiniciar valores del juego
        buttonPressCount = 0;
        currentProgressBarValue = 0;
        progressBar.value = currentProgressBarValue;
        countdownTime = 10.0f; // Reiniciar el tiempo (puedes ajustar este valor según tus necesidades)
    }
}
