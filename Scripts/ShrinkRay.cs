using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkRay : MonoBehaviour
{
    public float raycastDistance = 100f;
    public float scaleSpeed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); ;

            if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance) && hit.collider.CompareTag("Target"))
            {
                StartCoroutine(ScaleDown(hit.collider.gameObject));
            }
        }
    }

    IEnumerator ScaleDown(GameObject obj)
    {
        while (obj.transform.localScale.x > 0.5)
        {
            obj.transform.localScale -= new Vector3(scaleSpeed, scaleSpeed, scaleSpeed) * Time.deltaTime;
            yield return null;
        }

        
    }

}
