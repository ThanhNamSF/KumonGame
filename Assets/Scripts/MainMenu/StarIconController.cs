using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarIconController : MonoBehaviour {

    public float speedMovement;
    public float originalScale;
    public Transform target;
    public ParticleSystem puffStar;

    private bool isMovement;
    private bool isActive;
    private float maxDistance;
    private Vector3 scale;
    private float t;
    // Use this for initialization
    void Start()
    {
        maxDistance = Vector2.Distance(transform.position, target.position);
        scale = new Vector3(originalScale, originalScale, originalScale);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (isMovement)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speedMovement * Time.deltaTime);
                float currentDistance = Vector2.Distance(transform.position, target.position);
                float currentScale = originalScale - (1 - currentDistance / maxDistance) * originalScale;
                if (currentScale > 3f)
                {
                    transform.localScale = new Vector3(currentScale, currentScale, currentScale);
                }
                if (transform.position.y == target.position.y)
                {
                    SoundManager.instance.PLayCollectStar();
                    puffStar.transform.position = transform.position;
                    puffStar.Play(true);
                    isMovement = false;
                    isActive = false;
                    GameController.instance.IncreaseProcess();
                    gameObject.SetActive(false);
                }
            }
            else
            {
                t += Time.deltaTime;
                transform.localScale = Vector3.Lerp(transform.localScale, scale, t);
                if (transform.localScale == scale)
                {
                    StartCoroutine(WaitingForMovement());
                }
            }
        }
    }

    void OnEnable()
    {
        isActive = true;
        t = 0;
        transform.localScale = Vector3.zero;
    }

    IEnumerator WaitingForMovement()
    {
        yield return new WaitForSeconds(0.5f);
        isMovement = true;
    }
}
