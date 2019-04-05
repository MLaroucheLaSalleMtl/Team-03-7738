using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeFeedback : MonoBehaviour
{
    [SerializeField] private float timer = 0.575f;
    private bool frozen;

    public float Timer { get => timer; }
    public void Freeze()
    {
        if (!frozen)
        {
            StartCoroutine(Feedback());
        }

    }

    IEnumerator Feedback()
    {
        Debug.Log("Hit");
        frozen = true;
        float original = Time.timeScale;
        Time.timeScale = 0.3f;

        yield return new WaitForSecondsRealtime(timer);
        frozen = false;
        Time.timeScale = original;
    }
}
