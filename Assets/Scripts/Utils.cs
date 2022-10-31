using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static Vector3 CalculateMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            return hit.point;
        }
        return Vector3.negativeInfinity;
    }

    public static IEnumerator DelayEndTurn()
    {
        yield return new WaitForSeconds(1.5f);
        CombatManager.Instance.NextTurn();
    }
}
