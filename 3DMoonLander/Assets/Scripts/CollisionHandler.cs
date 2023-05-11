using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float levelLoadDelay = 1f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crashParticle;

    bool isTransitioning = false;
    bool collisiionDisable = false;

    AudioSource audio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RespondToDebugKeys();

    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKey(KeyCode.L)) { LoadNextLevel(); }
        else if (Input.GetKey(KeyCode.C))
        {
            collisiionDisable = !collisiionDisable; // toggle collision
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning || collisiionDisable) { return; }
        switch (collision.gameObject.tag)
        {
            case "Start":
                break;
            case "Obstacle":
                startCrashSequence();
                Debug.Log("This thing is Obstacle");
                break;
            case "Finish":
                startSuccessSequence();
                break;
            case "Fuel":
                Debug.Log("You picked  up fuel!");
                break;
            default:
                startCrashSequence();
                Debug.Log("You blewUP!");
                break;
        }

    }

    private void startSuccessSequence()
    {
        //성공했을때              
        isTransitioning = true;
        audio.Stop();
        audio.PlayOneShot(success);
        successParticle.Play();
        Movement movement = GetComponent<Movement>();
        movement.enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void startCrashSequence()
    {
        //크래쉬했을때 
        isTransitioning = true;
        audio.Stop();
        audio.PlayOneShot(crash);
        crashParticle.Play();
        Movement movement = GetComponent<Movement>();
        movement.enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void ReloadLevel()
    {
        //스테이지 재시작
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        //다음 스테이지
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
