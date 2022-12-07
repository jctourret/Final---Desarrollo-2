using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    enum Behaviors
    {
        Chaser,
        Jumper
    }
    [SerializeField] ITargetBehavior currentBehavior;
    [SerializeField] Transform target;
    [SerializeField] TargetAttributes attributes;
    private void Start()
    {
        float selectedBehaviour = Random.Range((float)Behaviors.Chaser,(float)Behaviors.Jumper);
        selectedBehaviour = Mathf.RoundToInt(selectedBehaviour);
        if(selectedBehaviour == (int)Behaviors.Chaser)
        {
            currentBehavior = new Chaser(attributes.speed,target,transform);
        }
        else
        {
            currentBehavior = new Jumper(GetComponent<CharacterController>());
        }
    }
    private void Update()
    {
        currentBehavior.move();
    }
}
