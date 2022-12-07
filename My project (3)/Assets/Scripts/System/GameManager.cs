using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Values")]
    [SerializeField] float totalTime = 60;
    [SerializeField] float currentTime;
    [SerializeField] float score;

    bool victory;
    int targetCounter;

    public static Action<float> onTimeUpdate;
    public static Action<float> onScoreUpdate;
    public static Action<bool> OnGameEnd;
    private void OnEnable()
    {
        TargetHealth.onTargetSpawn += AddTarget;
        TargetHealth.onTargetDestroy += EraseTarget;
    }

    private void OnDisable()
    {
        TargetHealth.onTargetSpawn -= AddTarget;
        TargetHealth.onTargetDestroy -= EraseTarget;

    }
    private void Start()
    {
        currentTime = totalTime;
    }
    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        onTimeUpdate?.Invoke(currentTime);
        if(currentTime <= 0.0f)
        {
            victory = false;
            OnGameEnd?.Invoke(victory);
        }
        else if(targetCounter == 0)
        {
            victory = true;
            OnGameEnd?.Invoke(victory);
        }
    }

    void UpdateScore(float addedScore)
    {
        score += addedScore;
        onScoreUpdate?.Invoke(score);
    }

    void AddTarget()
    {
        targetCounter++;
    }
    void EraseTarget(float pointsScored)
    {
        targetCounter--;
        UpdateScore(pointsScored);
    }
}