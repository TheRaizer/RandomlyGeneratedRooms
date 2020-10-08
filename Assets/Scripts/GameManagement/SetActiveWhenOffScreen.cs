using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveWhenOffScreen : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
