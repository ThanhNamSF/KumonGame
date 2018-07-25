using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CannonController : MonoBehaviour {

    public Transform firePosition;
    public Animator cannonAnim;

    public float minAngle;
    public float maxAngle;
    private bool canFire;
    // Use this for initialization
    void Start()
    {
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ChallengeControllerLv1.gameStart && !ChallengeControllerLv1.isPauseGame)
        {
            RotateFollowMouse();
            if (canFire)
            {
                if (Input.GetMouseButtonDown(0) && !IsPointerOverUIObject())
                {
                    StartCoroutine(Shoot());
                }
            }
        }
    }

    private void RotateFollowMouse()
    {
        Vector2 cannonPosition = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(cannonPosition, mousePosition);
        float angleZ = angle - 90;
        angleZ = Mathf.Clamp(angleZ, minAngle, maxAngle);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angleZ));
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(b.y - a.y, b.x - a.x) * Mathf.Rad2Deg;
    }

    IEnumerator Shoot()
    {
        cannonAnim.SetTrigger("Shoot");
        //SoundManager.instance.CannonShooting();
        canFire = false;
        GameObject cannonBullet = ObjectPooler.SharedIntance.GetPooledObject("bullet");
        if (cannonBullet != null)
        {
            cannonBullet.transform.position = firePosition.position;
            cannonBullet.transform.rotation = transform.rotation;
            cannonBullet.SetActive(true);
        }
        yield return new WaitForSeconds(0.3f);
        canFire = true;
    }

    //Check mouse over on pause button or not
    private bool IsPointerOverUIObject()
    {
        var eventDataCurrentPosition = new PointerEventData(EventSystem.current)
        {
            position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
        };
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        if (results.Count > 0)
            return results[0].gameObject.tag == "Pause";
        return false;
    }
}
