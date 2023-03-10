using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleMove : MonoBehaviour

{

    [Header("Rotate Parameters")]
    //Rotation Parameters
    [SerializeField] Vector3 rotate;
    [SerializeField] float RDuration;
    public int loopAmt;
    public LoopType Loop;
    public bool IsRotatable;

    [Header("Movement Parameters")]
    //Movement Parameters
    [SerializeField] Vector3 MStartPos;
    [SerializeField] Vector3 MEndPos;
    [SerializeField] float MDuration;
    public bool isMoveable;

    //Rotate Loop Parameters
    [Header("Rotate Loop Parameters")]
    [SerializeField] Vector3 RStartPos;
    [SerializeField] Vector3 REndPos;
    [SerializeField] float RLDuration;

    public bool isRotateLoop;

    // Start is called before the first frame update
    void Start()
    {
        if(isMoveable == true)
        {
            MStartMovement();
        }

        if(IsRotatable == true)
        {
            {
                transform.DOLocalRotate(rotate, RDuration, RotateMode.LocalAxisAdd).SetLoops(loopAmt, Loop).SetEase(Ease.Linear);
            }
        }
        if (isRotateLoop == true)
        {
            RStartMovement();
        }
    }

    public void MStartMovement()
    {
        transform.DOLocalMove(MEndPos, MDuration).OnComplete(() => MRestartMovement()).SetEase(Ease.Linear);
    }

    public void MRestartMovement()
    {
        transform.DOLocalMove(MStartPos, MDuration).OnComplete(() => MStartMovement()).SetEase(Ease.Linear);
    }

    public void RStartMovement()
    {
        transform.DOLocalRotate(rotate, RDuration, RotateMode.LocalAxisAdd).OnComplete(() => RRestartMovement()).SetEase(Ease.Linear);
    }

    public void RRestartMovement()
    {
        transform.DOLocalRotate(rotate, RDuration, RotateMode.LocalAxisAdd).OnComplete(() => RStartMovement()).SetEase(Ease.Linear);
    }
    // Update is called once per frame
    void Update()
    {
           
    }
}
