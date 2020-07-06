using System;
using System.Collections;
using System.Linq;
using System.Media;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] GameTimer gameTimer = null;
    [SerializeField] GameObject spawnerContainer = null;

    [SerializeField] LoadingScreen loadingScreen = null;
    AudioSource winSFXSource = null;
    [SerializeField] TMPro.TMP_Text winText = null;
    bool isObservingEnemies = false;
    private Coroutine onEnemiesDeadCoroutine;
    private AttackerSpawner[] attackerSpawners;


    void Start()
    {
        gameTimer.HasTerminated = OnTimerTerminated;
        attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        winSFXSource = GetComponent<AudioSource>();
    }

    void OnTimerTerminated()
    {
        gameTimer.enabled = false;
        StopSpawning();
        isObservingEnemies = true;
    }

    private void StopSpawning()
    {
        attackerSpawners.ToList().ForEach(attackerSpawner => attackerSpawner.StopSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        if (isObservingEnemies)
        {
            var attackers = FindObjectsOfType<Attacker>();
            if (attackers.Length == 0)
            {
                isObservingEnemies = false;
                onEnemiesDeadCoroutine = StartCoroutine(OnEnemiesDead());
            }
        }
    }

    IEnumerator OnEnemiesDead()
    {
        winText.enabled = true;
        winSFXSource.Play();
        yield return new WaitForSeconds(5);
        loadingScreen.LoadNextScene();
        StopCoroutine(onEnemiesDeadCoroutine);
    }
    
}
