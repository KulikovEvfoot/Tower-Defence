using UnityEngine;

public class ObjectAnimator : MonoBehaviour
{
    // Начальный масштаб объекта (изначально будет взят из объекта)
    private Vector3 startScale;
    public Vector3 initialScaleFactor = new Vector3(0.5f, 0.5f, 0.5f); // Фактор уменьшения от начального масштаба

    // Продолжительность анимации подъема и изменения масштаба в секундах
    public float liftDuration = 2f;
    public float scaleDuration = 2f;
    // Параметры анимации желе
    public float jellyDuration = 1f;
    public float jellyMagnitude = 0.1f;
    public int jellyFrequency = 4;

    // Таймер до начала анимации
    public float preAnimationDelay = 1f;

    // Время, прошедшее с начала анимации
    private float elapsedTime = 0f;
    // Время, прошедшее с начала задержки
    private float delayTime = 0f;

    // Флаги для отслеживания стадий анимации
    private bool isAnimating = false;
    private bool isLiftCompleted = false;
    private bool isScaleCompleted = false;
    private bool isDelayCompleted = false;
    private bool isSoundPlayed = false;

    // Начальная высота ниже уровня сцены
    public float initialHeightBelowGround = -5f;

    // Начальная и конечная позиции объекта
    private Vector3 startPosition;
    private Vector3 endPosition;

    // Компонент AudioSource для воспроизведения звука
    private AudioSource audioSource;
    public AudioClip soundEffect;

    void Start()
    {
        // Сохраняем начальный масштаб объекта
        startScale = transform.localScale;
        
        // Определяем начальный уменьшенный масштаб
        Vector3 initialScale = Vector3.Scale(startScale, initialScaleFactor);

        // Устанавливаем начальный уменьшенный масштаб
        transform.localScale = initialScale;

        // Определяем начальную позицию
        startPosition = transform.position;

        // Определяем конечную позицию ниже уровня сцены
        endPosition = startPosition + new Vector3(0, initialHeightBelowGround, 0);

        // Устанавливаем объект в начальное положение ниже уровня сцены
        transform.position = endPosition;

        // Получаем компонент AudioSource (если он уже добавлен к объекту)
        audioSource = GetComponent<AudioSource>();

        // Запуск анимации при старте сцены
        StartAnimation();
    }

    void Update()
    {
        if (isAnimating)
        {
            if (!isDelayCompleted)
            {
                // Увеличиваем прошедшее время задержки
                delayTime += Time.deltaTime;

                // Проверяем, завершена ли задержка
                if (delayTime >= preAnimationDelay)
                {
                    isDelayCompleted = true;
                    elapsedTime = 0f; // Сброс времени для основной анимации
                }
            }
            else
            {
                // Увеличиваем прошедшее время основной анимации
                elapsedTime += Time.deltaTime;

                if (!isLiftCompleted)
                {
                    // Вычисляем процент завершения анимации подъема
                    float t = Mathf.Clamp01(elapsedTime / liftDuration);

                    // Интерполируем позицию
                    transform.position = Vector3.Lerp(endPosition, startPosition, t);

                    // Проверяем, завершен ли подъем
                    if (t >= 1f)
                    {
                        isLiftCompleted = true;
                        elapsedTime = 0f; // Сброс времени для следующей стадии
                    }
                }
                else if (!isScaleCompleted)
                {
                    // Воспроизводим звук после подъема, но до изменения масштаба
                    if (!isSoundPlayed)
                    {
                        if (audioSource != null && soundEffect != null)
                        {
                            audioSource.PlayOneShot(soundEffect);
                        }
                        isSoundPlayed = true;
                    }

                    // Вычисляем процент завершения анимации изменения масштаба
                    float t = Mathf.Clamp01(elapsedTime / scaleDuration);

                    // Интерполируем масштаб
                    transform.localScale = Vector3.Lerp(Vector3.Scale(startScale, initialScaleFactor), startScale, t);

                    // Проверяем, завершена ли анимация изменения масштаба
                    if (t >= 1f)
                    {
                        isScaleCompleted = true;
                        elapsedTime = 0f; // Сброс времени для следующей стадии
                    }
                }
                else
                {
                    // Анимация желе
                    float t = Mathf.Clamp01(elapsedTime / jellyDuration);
                    float jellyEffect = Mathf.Sin(t * Mathf.PI * jellyFrequency) * jellyMagnitude * (1 - t);

                    // Применяем эффект желе к масштабу
                    transform.localScale = startScale + new Vector3(jellyEffect, jellyEffect, jellyEffect);

                    // Останавливаем анимацию, если она завершена
                    if (t >= 1f)
                    {
                        isAnimating = false;
                        elapsedTime = 0f;
                    }
                }
            }
        }
    }

    // Функция для запуска анимации
    public void StartAnimation()
    {
        isAnimating = true;
        isDelayCompleted = false;
        isLiftCompleted = false;
        isScaleCompleted = false;
        isSoundPlayed = false;
        elapsedTime = 0f;
        delayTime = 0f; // Сброс времени задержки
    }
}
