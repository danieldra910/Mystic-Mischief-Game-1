using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLichDragon : MonoBehaviour
{
    public List<GameObject> teleportPoints = new List<GameObject>();
    public List<Transform> teleportPoints2 = new List<Transform>();
    public bool Teleport;
    public GameObject tpDestination;
    public float Speed;
    public GameObject Player;
    public Rigidbody  projectile;
    public bool attacked;
    public bool attacked2;
    public float resetAttackTime;
    public float projectileSpeed;
    public float meleeDist;
    public float attackTimes;
    public float chaseTime;
    public Transform WarpLocation;
    private bool ChasingPlayer;
    public float maxAttackTimes;
    private bool CanAttack;
    private float startSpeed;
    public bool closeToPlayer;
    public float timeUntilChase;
    public float resetChaseTime;
    private int randomNumber;
    private int randomNumber2;
    public Animator anim;
    public int teleportTimes;
    public bool Die;
    public ParticleSystem death;


    // Start is called before the first frame update
    void Start()
    {
        // startPosition = teleportPoints[3].transform;
        startSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(Player.transform.position, transform.position);
        if(closeToPlayer == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
        }

        if(dist <= meleeDist)
        {
            closeToPlayer = true;
        }
        else
        {
            closeToPlayer = false;
        }

        if (Teleport == true)
        {
            WarpToNewLocation();
        }

        if (attacked == false && CanAttack == true)
        {
            Ranged();
        }
        var q = Quaternion.LookRotation(new Vector3(Player.transform.position.x,  transform.position.y, Player.transform.position.z) - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, q, Speed * Time.deltaTime);
        // else
        // {
        //     Speed = startSpeed;
        // }
        // if (dist <= meleeDist)
        // {
        //     CanAttack = false;
        //     Melee();
        // }
        if (attackTimes >= maxAttackTimes)
        {
            if (randomNumber2 == 1)
            {
            ChasingPlayer = true;
            CanAttack = false;
            Invoke(nameof(ChasePlayer), timeUntilChase);
            }
            if (randomNumber2 == 3 || randomNumber2 == 4 || randomNumber2 == 2)
            {
                WarpAfterAttack();
            }
        }
        // Transform.LookAt(Player.transform.position);
    }

    public void WarpToNewLocation()
    {
        death.Play(true);
        anim.SetTrigger("Teleport");
        //Debug.Log("Teleporting");
        foreach(GameObject tpPoint in teleportPoints)
        {
            if (tpPoint.GetComponent<TeleportPoints>().Colliding == false)
            {
                tpDestination = tpPoint;
                break;
            }
        }
        transform.position = tpDestination.transform.position;
        Teleport = false;
    }

    public void WarpAfterAttack()
    {
        death.Play(true);
        anim.SetTrigger("Teleport");
        //Debug.Log("Teleporting");
        WarpLocation = teleportPoints2[teleportTimes];
        transform.position = WarpLocation.position;
        Teleport = false;
        attacked2 = false;
        NewRandomNumber2();
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player") && ChasingPlayer == false && Die == false)
        {
        Teleport = true;
        }
        if (!other.gameObject.CompareTag("Player") && ChasingPlayer == false && Die == true)
        {
            if (!other.gameObject.CompareTag("PickUp"))
            {
                Teleport = true;
            }
            if (other.gameObject.CompareTag("PickUp"))
            {
                if (other.gameObject.GetComponent<Item>().canKill == true && Die == true)
                {
                    SwordDroppedOnTheHead();
                }
            }
        }
        if (other.gameObject.CompareTag("DragonOnly"))
        {
            //Debug.Log("HitPlayer");
            ResetAttackChase();
        }
    }

        void Ranged()
    {
        anim.SetTrigger("Attack");
        // anim.SetTrigger("Spit");
        Rigidbody clone;
        clone = Instantiate(projectile, transform.position, Player.transform.rotation);
        // Speed = 0;
        //projectile.LookAt(Player.transform);

        clone.velocity = (Player.transform.position - clone.position).normalized * projectileSpeed;
        Invoke(nameof(ResetAttack), resetAttackTime);
        attacked = true;
        attackTimes++;
        // NewRandomNumber2();
    }

   // public void Melee() //Empty delete if unused
   // {
   //
   // }

        void ChasePlayer()
    {
        if (ChasingPlayer == true)
        {
        int LayerPlayerOnly = LayerMask.NameToLayer("PlayerOnly");
        gameObject.layer = LayerPlayerOnly;
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
        // Speed = startSpeed;
        // Invoke(nameof(ResetAttack2), chaseTime); 
        }
    }

    //This is for reseting the melee attack.
    void ResetAttackChase()
    {
        attacked2 = false;
        Invoke(nameof(ResetAttackRanged), resetChaseTime);
        int LayerDragon = LayerMask.NameToLayer("Dragon");
        gameObject.layer = LayerDragon;
        NewRandomNumber();
        // transform.position = startPosition.position;
        WarpAfterAttack();
        attackTimes = 0;
        ChasingPlayer = false;
    }
    
    public void ResetAttackRanged()
    {
        CanAttack = true;
    }

    public void ResetAttack()
    {
        attacked = false;
        // Speed = startSpeed;
    }

    int lastNumber;
    //This is the random number generator. This is used for selecting patrol points at random.
    public virtual void NewRandomNumber()
    {
        randomNumber = UnityEngine.Random.Range(1, 3);
        if (randomNumber == lastNumber)
        {
            randomNumber = UnityEngine.Random.Range(1, 3);
        }
        lastNumber = randomNumber;
    }

    int lastNumber2;
    //This is the random number generator. This is used for selecting patrol points at random.
    public virtual void NewRandomNumber2()
    {
        // randomNumber2 = UnityEngine.Random.Range(1, 4);
        // if (randomNumber2 == lastNumber2)
        // {
        //     randomNumber = UnityEngine.Random.Range(1, 4);
        // }
        // lastNumber2 = randomNumber2;
        if (teleportTimes <= teleportPoints2.Count - 1)
        {
            teleportTimes = teleportTimes + 1;
        }
        if (teleportTimes > teleportPoints2.Count - 1)
        {
            teleportTimes = 0;
        }
    }
    public void SwordDroppedOnTheHead()
    {
        if(death !=null)
        {
            death.Play(true);
            Destroy(gameObject, 0.5f);
        }
    }
}
