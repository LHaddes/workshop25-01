using UnityEngine;
using Pathfinding;

public class EnemiAI : MonoBehaviour
{
    public Transform target;

    public float speed;
    public float nextWaypointDistance = 3f;
    

    private float _hitRate = 1f;
    
    private Path _path;

    public int life = 2;
    public int damage = 1;
    
    private int _currentWaypoint;

    public bool playerInRange = false;
    
    private bool _reachEndOnPath;

    private Seeker _seeker;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        _seeker = GetComponent<Seeker>();
        _rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (_seeker.IsDone())
            _seeker.StartPath(_rb.position, target.position, OnPathComplete);
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (playerInRange)
        {
            _hitRate -= Time.deltaTime;
            if (_hitRate <= 0)
            {
                target.GetComponent<PlayerLife>().Hurt(damage);
                Debug.Log("je touche le joueur");
                _hitRate = 1f;
            }
        }
        
        if (life <= 0)
        {
            target.GetComponent<PlayerMovement>().score += 15;
            GameplayManager.gameplayManager.actualNbEnemies--;
            GameplayManager.gameplayManager.UpdateEnemis();
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_path == null)
        {
            return;
        }

        if (_currentWaypoint >= _path.vectorPath.Count)
        {
            _reachEndOnPath = true;
            return;
        }
        else
        {
            _reachEndOnPath = false;
        }

        Vector2 direction = ((Vector2) _path.vectorPath[_currentWaypoint] - _rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        _rb.AddForce(force);

        float distance = Vector2.Distance(_rb.position, _path.vectorPath[_currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            _currentWaypoint++;
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            _path = p;
            _currentWaypoint = 0;
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Barricade"))
        {
            if (other.GetComponent<Barricades>().life == 0)
            {
                speed = 250;
            }
            else
            {
                speed = 0;
                other.GetComponent<Barricades>().life -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}