using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    public Slider shieldSlider;
    public Slider healthSlider;
    public GameObject RouletteMiniGame;
    public GameObject attackButton;
    public GameObject miniGameContainer;

    private float maxShield = 50f;
    private float maxHealth = 100f;

    private bool shieldBroken = false;

    // Referencia al controlador del nuevo minijuego
    [SerializeField] private ButtonMashingGameController buttonMashingGameController;

    private void Start()
    {
        miniGameContainer.SetActive(false);
        InitializeLife(maxHealth, maxShield);
    }

    private void Update()
    {
        if (healthSlider.value == 0)
        {
            Debug.Log("Game Over");
        }
    }

    public void ChangeMaxLife(float maxHealth, float maxShield)
    {
        this.maxHealth = maxHealth;
        this.maxShield = maxShield;

        healthSlider.maxValue = maxHealth;
        shieldSlider.maxValue = maxShield;
    }

    public void ChangeLife(float damage)
    {
        if (!shieldBroken)
        {
            if (shieldSlider.value >= damage)
            {
                shieldSlider.value -= damage;
                RouletteMiniGame.SetActive(false);
                attackButton.SetActive(true);
            }
            else
            {
                float remainingDamage = damage - shieldSlider.value;
                shieldSlider.value = 0;
                healthSlider.value -= remainingDamage;

                // Indicar que el escudo se ha roto
                shieldBroken = true;

                miniGameContainer.SetActive(true);
                // Llamar al nuevo minijuego cuando el escudo se rompe
                buttonMashingGameController.StartButtonMashingGame();
            }
        }
    }

    public bool IsShieldBroken()
    {
        return shieldBroken;
    }

    public void RestoreVisualShield()
    {
        shieldSlider.value = maxShield;
        shieldBroken = false;
    }

    public void RestoreShield()
    {
        shieldSlider.value = maxShield;
        shieldBroken = false;
    }

    public void RecoverShield(float amount)
    {
        if (shieldSlider.value + amount <= maxShield)
        {
            shieldSlider.value += amount;
        }
        else
        {
            shieldSlider.value = maxShield;
        }
    }

    public void InitializeLife(float startingHealth, float startingShield)
    {
        ChangeMaxLife(startingHealth, startingShield);
        healthSlider.value = startingHealth;
        shieldSlider.value = startingShield;
    }
}
