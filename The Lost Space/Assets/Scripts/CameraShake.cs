using UnityEngine;
using System.Collections;
public class CameraShake : MonoBehaviour
{
    public Camera mainCamera;
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.position = new Vector3(transform.position.x + x, transform.position.y + y, -10f);
           
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = orignalPosition;
    }

    public IEnumerator Zoom(float duration, float magnitude)
    {
       float orignalPosition = mainCamera.orthographicSize;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            mainCamera.orthographicSize -= x;

            elapsed += Time.deltaTime;
            yield return 0;
        }
        mainCamera.orthographicSize = orignalPosition;
    }


}