using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour
{
    [SerializeField] GameObject _health;

    public void SetHP(float normal) {

        _health.transform.localScale = new Vector3(normal, 1f);
    }
    public IEnumerator SetHPsmooth(float newHp) {
        float currentHP = _health.transform.localScale.x;
        float changeAmt = currentHP - newHp;
        while (currentHP-newHp> Mathf.Epsilon) {
            currentHP -= changeAmt*Time.deltaTime;
            _health.transform.localScale = new Vector3(currentHP, 1f);
            yield return null;
        }
        _health.transform.localScale = new Vector3(newHp, 1f);
    }
}
