using UnityEngine;
using System.Collections;

public class NewBehaviourScript : EnnemyController
{
    public bool launcherOpen = false;
    public float openningTime = 1.0f;

    private Animator animator;
    private bool coroutineStarted = false;
	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        animator.SetBool("isLauncherOpen", launcherOpen);
	}

    public override void  Shoot ()
    {
        base.Shoot();
    }

    void openLauncher()
    {
        launcherOpen = true;
        if(coroutineStarted)
        {
            StopCoroutine(closeLauncher());
        }
        else
        {
            coroutineStarted = true;
        }
        
        StartCoroutine(closeLauncher());
    }

    IEnumerator closeLauncher()
    {
        yield return new WaitForSeconds(openningTime);
        launcherOpen = false;
        coroutineStarted = false;
    }
}
