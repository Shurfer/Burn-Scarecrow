using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings;

    [SerializeField] GameObject model;
    [SerializeField] ParticleSystem[] particles;
    [SerializeField] Slider healthSlider;
    [SerializeField] Slider waterSlider;

    int health;
    int water;

    bool burn;

    Coroutine oldCoroutine;


    void Start()
    {
        healthSlider.maxValue = health = gameSettings.startHealthEnemy;
        healthSlider.value = health;
        waterSlider.maxValue = 100;
        StartCoroutine(timerToFireDamage());
    }

    public void Hit(int damage)
    {
        if (water > 0)
            damage -= 10;
        else if (burn)
            damage += 10;

        SetHealth(damage);
    }

    void SetHealth(int damage)
    {
        health -= damage;
        healthSlider.value = health;
        if (health <= 0)
            model.SetActive(false);
    }

    public void WaterDamage(int damage)
    {
        burn = false;
        if (oldCoroutine != null)
            StopCoroutine(oldCoroutine);
        
        water += damage;
        if (water > gameSettings.maxWaterValue)
            water = gameSettings.maxWaterValue;
        waterSlider.value = water;
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].Stop();
        }
    }

    public void FireOn(int damage)
    {
        burn = true;
        if (water > 0)
        {
            water -= damage;
            waterSlider.value = water;
        }
        else
        {
            SetHealth(damage);
            if (oldCoroutine != null)
                StopCoroutine(oldCoroutine);
            oldCoroutine = StartCoroutine(timerToFireOff());

            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].Play();
            }
        }
    }

    IEnumerator timerToFireOff()
    {
        yield return new WaitForSeconds(10);
        burn = false;
    }

    IEnumerator timerToFireDamage()
    {
        yield return new WaitForSeconds(1);
        if (burn)
            health -= gameSettings.burnDamage;
        StartCoroutine(timerToFireDamage());
    }

    void Reset()
    {
        health = gameSettings.startHealthEnemy;
        healthSlider.value = health;
        burn = false;
        water = 0;
        waterSlider.value = 0;
        model.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Reset();
    }
}