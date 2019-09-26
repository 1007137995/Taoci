using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Move();
    }

    private void Move()
    {
        transform.DOLocalMoveY(-1, 0.5f).OnComplete(delegate 
        {
            transform.DOLocalMoveY(0, 0.5f).OnComplete(delegate
            {
                Move();
            });
        });
    }

    private void Update()
    {
        //transform.LookAt(new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z));
    }
}
