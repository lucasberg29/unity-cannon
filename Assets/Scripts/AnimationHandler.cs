using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public void DestroyEnemy()
    {
        GetComponentInParent<Enemy>().DestroyEnemy();
    }
}
