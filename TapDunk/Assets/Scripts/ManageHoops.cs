using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageHoops : MonoBehaviour {
    public Transform leftHoop;
    public Transform rightHoop;
    public float offscreenAmount;
	// Use this for initialization
	void Start () {
        float leftX = Camera.main.ScreenToWorldPoint(new Vector3(0, leftHoop.position.y, leftHoop.position.z)).x;
        float rightX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, rightHoop.position.y, rightHoop.position.z)).x;
        leftHoop.position = new Vector3(leftX, leftHoop.position.y, leftHoop.position.z);
        rightHoop.position = new Vector3(rightX, rightHoop.position.y, rightHoop.position.z);
        transform.position = new Vector3(-offscreenAmount, transform.position.y, transform.position.z);

    }

    // Update is called once per frame
    public void ShiftHoops () {
        StartCoroutine(ShiftHoops(1));
	}

    private IEnumerator ShiftHoops(float time)
    {
        float elapsedTime = 0;
        float initialX = transform.position.x;
        float targetX;
        yield return new WaitForSeconds(.5f);
        if (initialX > 0)
        {
            targetX = -offscreenAmount;
            rightHoop.localPosition = new Vector3(rightHoop.localPosition.x, Random.Range(-1.5f, 3.0f), rightHoop.localPosition.z);
        }
        else
        {
            targetX = offscreenAmount;
            leftHoop.localPosition = new Vector3(leftHoop.localPosition.x, Random.Range(-1.5f, 3.0f), leftHoop.localPosition.z);
        }
        while (elapsedTime < time)
        {
            float appliedX = Mathf.Lerp(initialX, targetX, elapsedTime);
            transform.position = new Vector3(appliedX, transform.position.y, transform.position.z);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }
}
