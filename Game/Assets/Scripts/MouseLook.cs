using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MouseLook : MonoBehaviour
{
    IEnumerator Rotate(Transform Parent, float duration, float angle)
    {
        float startRotation = Parent.eulerAngles.y < 180 ? Parent.eulerAngles.y : Parent.eulerAngles.y - 360;
        float endRotation = angle < 180 ? angle : angle - 360;
        if (startRotation != 0 && startRotation != -90)
            yield break;
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration);
            Parent.eulerAngles = new Vector3(Parent.eulerAngles.x, yRotation, Parent.eulerAngles.z);
            yield return null;
        }
    }

    private Transform ParentTransform;
    private GameObject Player;
    private void Awake()
    {
        ParentTransform = transform.parent.transform;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public float Weight = 3;
    void OnMouseDown()
    {
        float angle = ParentTransform.eulerAngles.y == 0 ? -90 : 0;
        if (Vector3.Distance(Player.transform.position, transform.position) < 3)
            //SceneManager.LoadScene("NewSCene");
            StartCoroutine(Rotate(ParentTransform, Weight, angle));
    }
}