using System;
using UnityEngine;
using DG.Tweening;

public class TweenUnitMenu : MonoBehaviour
{
    public RectTransform unitMenuTransform;
    public static TweenUnitMenu TweenUnitMenuInstance;
    private Vector2 targetPos = new Vector2(0, -350);
    private Vector2 firstPos = new Vector2(0, -750);

    private void Awake()
    {
        if (TweenUnitMenuInstance == null)
            TweenUnitMenuInstance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        unitMenuTransform.position = new Vector2(0, -700);
    }

    private void OnEnable()
    {
        unitMenuTransform.DOAnchorPos(targetPos, 0.3f).From(firstPos);
    }

    public void HideMenuAnim()
    {
        unitMenuTransform.DOAnchorPos(firstPos, 0.3f).From(targetPos);
    }
}