using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour, IPlayer
{
    [SerializeField]
    private float _moveSpeed = 1.0f;
    [SerializeField]
    private bool _godMode = false;
    public float Speed {  get => _moveSpeed;  set => _moveSpeed += value; }
    public bool God {  get => _godMode; set => _godMode = value; }
    private Rigidbody _rb = null;
    private float _h;
    private float _v;
    private float _jump;
    private bool _isGrounded = false;
    [SerializeField]
    private float _jumpPower = 1.0f;
    [SerializeField]
    private Transform _goalPosition;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");
        _jump = Input.GetAxisRaw("Jump");
    }

    private void FixedUpdate()
    {
        Move();
        if (_jump > 0 && _isGrounded)
        {
            _rb.AddForce(transform.up * _jumpPower, ForceMode.Impulse);
        }
    }

    private void Move()
    {
        var dis = Vector3.Distance(_goalPosition.position, this.transform.position);

        if (dis < 5)
        {
            _rb.velocity = Vector3.zero;
            return;
        }

        Vector3 dir = _goalPosition.position - this.transform.position;
        dir.y = 0;
        dir = dir.normalized * _moveSpeed;
        float y = _rb.velocity.y;

        _rb.velocity = dir * _moveSpeed + Vector3.up * y;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }
        else if (other.gameObject.TryGetComponent<IItem>(out IItem item))
        {
            item.Execute(this);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            _isGrounded = false;
        }
    }
}
