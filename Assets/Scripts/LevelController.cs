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
    AudioSource audioSource = null;
    [SerializeField] AudioClip musicClip = null;
    [SerializeField] AudioClip winSFXClip = null;
 
    [SerializeField] TMPro.TMP_Text winText = null;
    bool isObservingEnemies = false;
    private Coroutine onEnemiesDeadCoroutine;
    private AttackerSpawner[] attackerSpawners;
    private DefenderSpawner defenderSpawner = null;
    [SerializeField] GameObject loosePanel = null;

    void Start()
    {
        gameTimer.HasTerminated = OnTimerTerminated;
        attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        defenderSpawner = FindObjectsOfType<DefenderSpawner>().First();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.Play();
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
        StopLevel();
        winText.enabled = true;
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.PlayOneShot(winSFXClip);
        yield return new WaitForSeconds(5);
        loadingScreen.LoadNextScene();
        StopCoroutine(onEnemiesDeadCoroutine);
    }

    public void OnPlayerDidLoose()
    {
        StopLevel();

        loosePanel.SetActive(true);
    }

    public void OnRestartLevel()
    {
        loadingScreen.RestartLevel();
    }

    public void OnGoToMainMenu()
    {
        StopLevel();
        loadingScreen.GoToMenu();
    }

    private void StopLevel()
    {
        defenderSpawner.SetDefenderPrefab(null);
        defenderSpawner.enabled = false;
        StopLookingForEnemies();
        StopSpawning();
        CancelCoroutines();
    }

    private void StopLookingForEnemies()
    {
        isObservingEnemies = false;
    }

    private void CancelCoroutines()
    {
        if (onEnemiesDeadCoroutine != null)
        {
            StopCoroutine(onEnemiesDeadCoroutine);
        }
    }
}
