using UnityEngine;


public class Mover : MonoBehaviour
{
    [SerializeField] private float jumpForce = 13f;
    [SerializeField] public float gravity = 21.6f;
    [SerializeField] public float speed = 7f;
    
    private Rigidbody2D _rigidbody;

    private bool _isGrounded = true;
    private bool _isFalling = false;
    private float _prevJump = 0;

    public bool IsGrounded
    {
        get => _isGrounded;
        set => _isGrounded = value;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isFalling && _rigidbody.velocity.y == 0)
        {
            _isFalling = false;
            _isGrounded = true;
        }
        
        if (transform.position.y < _prevJump)
        {
            
            _isFalling = true;
        }

        

        _prevJump = transform.position.y;
    }
    
    void FixedUpdate(){
        _rigidbody.AddForce(Vector2.down * gravity);
        
    }


    public void Move(float horizontalInput)
    {
        transform.Translate(new Vector3(horizontalInput * speed, 0f) * Time.deltaTime);
    }
    
    

    public void Jump()
    {

        if (_isGrounded)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            
            _isGrounded = false;
        }
        
        
    }  
}
