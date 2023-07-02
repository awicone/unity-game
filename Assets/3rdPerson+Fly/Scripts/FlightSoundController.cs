using UnityEngine;

public class FlightSoundController : MonoBehaviour
{
    public FlyBehaviour flyBehaviour; // ссылка на FlyBehaviour
    public BasicBehaviour basicBehaviour; // ссылка на BasicBehaviour
    public float normalVolume = 0.5f; // громкость обычного полета
    public float sprintVolume = 1f; // громкость быстрого полета
    public float volumeChangeSpeed = 0.1f; // скорость изменения громкости

    private AudioSource audioSource; // источник звука

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // получаем компонент AudioSource
    }

    void Update()
    {
        float targetVolume; // целевая громкость
        // Проверяем, летит ли персонаж и использует ли спринт.
        if (flyBehaviour.IsFlying() && basicBehaviour.IsSprinting())
        {
            targetVolume = sprintVolume;
        }
        else if (flyBehaviour.IsFlying())
        {
            targetVolume = normalVolume;
        }
        else
        {
            targetVolume = 0f;
        }

        // Плавно меняем громкость до целевой
        audioSource.volume = Mathf.Lerp(audioSource.volume, targetVolume, volumeChangeSpeed * Time.deltaTime);
    }
}
