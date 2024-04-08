using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;




public class NewBehaviourScript : MonoBehaviour
{
    public List<GameObject> myObjects;
    public float delayBetweenObjects = .1f;
    public float animationDuration = .3f;


    [Header("Animation")]
    
    public Animator animator;
    public string triggerShow = "Show";
    public string triggerHide = "Hide";
    private bool _IsShowing = false;

    private void Awake()
    {
        //GetObjects();
        Hide();
    }
    private void GetObjects()
    {
        foreach (Transform t in GetComponentInChildren<Transform>())
        {
            if (t != transform)
                myObjects.Add(t.gameObject);

        }
    }

    private void Hide()
    {
        _IsShowing = false;
        foreach (GameObject g in myObjects)
        {
            g.SetActive(false);
        }
    }
    public void ShowItens()
    {
        if (_IsShowing)
        {
            Hide();
            animator.SetTrigger(triggerHide);
        }
        else
        {
            animator.SetTrigger(triggerShow);
            _IsShowing = true;   
          StartCoroutine(Show());
        
        
        }
    }
    IEnumerator Show()
    {
        foreach (GameObject g in myObjects)
        {
            yield return new WaitForSeconds(delayBetweenObjects);
            g.SetActive(true);
            g.transform.DOScale(0, animationDuration).From();
        }
    }

}
