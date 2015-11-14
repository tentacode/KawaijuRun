using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public struct ScenarioStep
{
    public enum EnnemyActions { wait, shoot, move };

    public EnnemyActions action;
    public float delayForNextStep;
}

public class EnnemyScenario : MonoBehaviour
{
    public List<ScenarioStep> steps;

    public ScenarioStep currentStep;
    
    public int currentStepPosition;

    private Action<ScenarioStep.EnnemyActions> controllerSetStateFunction;

    public void beginScenario(Action<ScenarioStep.EnnemyActions> changeStateCallback)
    {
        controllerSetStateFunction = changeStateCallback;
        ChangeStep(0);
    }
	
    public void ChangeStep (int stepPosition)
    {
        if (stepPosition < 0)
        {
            stepPosition = 0;
        }
             
        if(stepPosition >= steps.Count)
        {
            stepPosition = 0;
            Debug.Log("reset");
        }

        currentStep = steps[stepPosition];
        currentStepPosition = stepPosition;

        controllerSetStateFunction(currentStep.action);

        StartCoroutine(WaitForNextStep());
    }

    IEnumerator WaitForNextStep()
    {
        yield return new WaitForSeconds(currentStep.delayForNextStep);
        ChangeStep(currentStepPosition + 1);
    }
}
