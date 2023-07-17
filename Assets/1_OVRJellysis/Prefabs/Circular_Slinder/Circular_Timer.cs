using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Circular_Timer : MonoBehaviour
{
    public Slider round_slider;
    private bool isStarted = false;
    [SerializeField]
    private float round_time;
    public Image slider_color;
    [SerializeField]
    Color color_clider;
    public AudioSource timer;
    float timePassed = 0.0f;
    void Start()
    {
        //round_slider.maxValue =GameManager.Bear.playTimeEachBear;
        //round_time = GameManager.Bear.playTimeEachBear;
        //round_slider.value = 0;
    }
    void Update()
    {
        if (isStarted)
        {
            UpdateTime();
        }
    }

    void UpdateTime()
    {
        round_time -= Time.deltaTime;
        timePassed += Time.fixedDeltaTime;
        slider_color.color = Color.Lerp(Color.red, color_clider, round_time / timePassed);

        round_slider.value = round_time;
        if(round_time <= 10 && timer.isPlaying == false) timer.Play();
        if(round_time <= 0) timer.Stop();
    }
    public void ResetTimer()
    {
        //round_time = GameManager.Bear.playTimeEachBear;
        isStarted = true;
        timePassed = 0.0f;

        Color color_green;
        ColorUtility.TryParseHtmlString("#24873B", out color_green);
        color_clider = color_green;
    }
    /*    public Slider round_slider;
    [SerializeField]
    private float round_time;
    public float timerDuration = 100f; // Ÿ�̸��� �� �ð� (�� ����)
    private float timer = 0f; // ���� Ÿ�̸� ��

    private void Update()
    {
        // ����� �ð��� ������� Ÿ�̸Ӹ� ������ŵ�ϴ�.
        timer += Time.deltaTime;

        // Ÿ�̸��� ���� ��Ȳ�� ����մϴ� (0���� 1����)
        float progress = timer / timerDuration;

        // ���� ��Ȳ ���� 0�� 1 ���̷� �����մϴ�.
        progress = Mathf.Clamp01(progress);

        // ���� �ð��� ǥ���մϴ�.
        round_time = Mathf.Lerp(timerDuration, 0f, progress);
        Debug.Log("���� �ð�: " + round_time.ToString("F2") + " ��");
        round_slider.value = round_time;
        // Ÿ�̸Ӱ� ������ �ð��� �����ߴ��� Ȯ���մϴ�.
        if (progress >= 1f)
        {

            Debug.Log("Ÿ�̸� �Ϸ�!");
            // Ÿ�̸Ӱ� �Ϸ�Ǿ��� �� �����ؾ� �� ������ �߰��մϴ�.
        }
    }*/
}
