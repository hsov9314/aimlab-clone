using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PistolFire : MonoBehaviour
{
    public GameObject blackPistol;
    public bool isFiring = false;
    public AudioSource pistolShot;
    public AmmoDisplay ammoDisplay;
    public float toTarget;
    public TextMeshProUGUI scoreText;

    public int fireCount;
    public int score;

    [SerializeField]
    Camera fpsCam;

    public static PistolFire instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    IEnumerator FirePistol()
    {
        isFiring = true;
        fireCount++;
        blackPistol.GetComponent<Animator>().Play("FireM1911");
        toTarget = PlayerCasting.distanceFromTarget;
        pistolShot.Play();

        //called when bullet hits object
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward.normalized, out RaycastHit hitInfo))
        {
            Debug.Log(hitInfo.collider.gameObject.tag);
            if(hitInfo.collider.gameObject.tag == "Sphere")
            {
                hitInfo.collider.gameObject.SetActive(false);
                score++;
                scoreText.text = score.ToString();
                GenerateSpherePrefabs.instance.initiateSpheres();
            }
        }

        yield return new WaitForSeconds(0.25f);

        blackPistol.GetComponent<Animator>().Play("New State");
        isFiring = false;
    }

    // Update is called once per frame
    void Update()
    {   

        if (Input.GetButtonDown("Fire1"))
        {
            if(isFiring == false)
            {
                StartCoroutine(FirePistol());
            }
        }

        if (Input.GetButtonDown("Interact"))
        {
            if (!CountDownTimer.instance.isStarted())
            {
                GenerateSpherePrefabs.instance.initiateSpheres();
                CountDownTimer.instance.startCountDown(15.0f);
            }
        }
    }

}
