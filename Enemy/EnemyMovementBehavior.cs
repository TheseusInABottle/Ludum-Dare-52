using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehavior : MonoBehaviour
{
    public string foxName;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		switch (foxName)
		{
            case null: Debug.Log("Null Name on the fox dood");
                break;
            case "4fb": animator.Play(foxName);
                break;
            case "3ftr": animator.Play(foxName);
                break;
            case "outer": animator.Play(foxName);
                break;
		}
    }
}
