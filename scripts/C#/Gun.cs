using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //Public objects/gameobjects
    private SC_FPSController bool_script;

    public Camera fpsCam;
    public GameObject FPSPlayer;
    public ParticleSystem muzzleFlash;
    public ParticleSystem shellDrop;
    public AudioSource source;
    public AudioClip Drop;
    public AudioClip Fire;
    public Animator animator;
    public GameObject Ammo_count;
    
    //Public and private values
    private float fireRate = 0.1f;
    public float nextFire = 0.0f;
    public float damage = 10f;
    public float range = 100f;
    public int maxAmmo = 30;
    private int currentAmmo;
    public float reloadTime = 2.10f;
    private bool isReloading = false;

    //Runs at the beginning of the scripts
    void Start ()
    {
        bool_script = FPSPlayer.GetComponent<SC_FPSController>();
        currentAmmo = maxAmmo;
    }
    // Update is called once per frame
    void Update()
    {
        Ammo_count.GetComponent<TMPro.TextMeshProUGUI>().text = currentAmmo.ToString();
        if (bool_script.editWeapon == false) //Listens to the editWeapon value if it is false
        {
            animator.SetBool("EditWeapon", false);
            if (isReloading)
                return;
            if (currentAmmo <= 0)
            {
                animator.SetBool("RecoilHip", false);
                StartCoroutine(Reload());
                return;
            }
            if (Input.GetButton("Fire1") && Time.time >= nextFire)
            {
                ShootAll();
            }
            if (Input.GetMouseButtonUp(0))
            {
                animator.SetBool("RecoilHip", false);
                source.PlayOneShot(Drop);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (currentAmmo >= 30) //Checks if the gun has more then 30 bullets
                {
                    return;
                }
                else
                {
                    animator.SetBool("RecoilHip", false); //Checks if the gun has less then 30 bullets
                    StartCoroutine(Reload()); //Executes the reload animation.
                    return;
                }
            }
        }
        // Edit weapon attachments animation
        if (bool_script.editWeapon == true)
        {
            animator.SetBool("EditWeapon", true); 
            return;
        }
        
        // Reload weapon animation
        IEnumerator Reload()
        {
            isReloading = true;
            animator.SetBool("Reloading", true);
            Debug.Log("Reloaded");
            yield return new WaitForSeconds(reloadTime);
            animator.SetBool("Reloading", false);
            currentAmmo = maxAmmo;
            isReloading = false;
        }

        // Full auto fire and semi-auto fire for gun.
        void ShootAll()
        {
            animator.SetBool("RecoilHip", true);
            Ammo_count.GetComponent<TMPro.TextMeshProUGUI>().text = currentAmmo.ToString();
            nextFire = Time.time + fireRate;
            currentAmmo--;
            muzzleFlash.Play();
            shellDrop.Play();
            source.PlayOneShot(Fire);
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
}