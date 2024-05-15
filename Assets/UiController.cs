using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UiController : MonoBehaviour
{
    public GameObject doortext;
    void Start()
    {
        EventHandler.instance.OnDoorTriggerEnter += OnDoorOpen;
        EventHandler.instance.OnDoorTriggerExit += OnDoorClosed;
    }

    public void OnDoorOpen(int id)
    {
        doortext.SetActive(true);
        doortext.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutBack);
    }

    public void OnDoorClosed(int id)
    {
        doortext.transform.DOScale(Vector3.zero, 0.2f).OnComplete(() => { doortext.SetActive(false); });
    }
    
    private void OnDisable()
    {
        EventHandler.instance.OnDoorTriggerEnter -= OnDoorOpen;
        EventHandler.instance.OnDoorTriggerExit -= OnDoorClosed;
    }
}
