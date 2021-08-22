using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TwoPlayer : MonoBehaviour
{
    [SerializeField] private GameObject upperBalls;
    [SerializeField] private GameObject lowerBalls;

    private const float XMirrorOffset = 1.2f;
    private const float DelayTime = 0.05f;
    private float _speed;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        Application.targetFrameRate = 120;
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _speed = Configs.Speed;
        
    }

    // Update is called once per frame
    private void Update()
    {
        _rigidbody2D.velocity = new Vector2(0, _speed);
    }

    public void OnUpperClicked()
    {
        MirrorUpperBalls();
    }

    public void OnLowerClicked()
    {
        MirrorLowerBalls();
    }

    private void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (gameObject.tag.Equals(collidedObject.tag))
        {
            // OK
            _speed = -_speed; // reverse moving direction

            // Change Player Color
            var random = GetRandomNumber();
            if (random > 0)
            {
                StartCoroutine(ChangePlayerColor(DelayTime));
            }
        }
        else
        {
            // GameOver
            SceneLoader.LoadGameOver();
            // todo: save looser player
            if (collidedObject.gameObject.transform.parent.name.Equals("Upper"))
            {
                
            }
        }
    }

    private void MirrorUpperBalls()
    {
        var upperPosition = upperBalls.transform.position;
        upperBalls.transform.position = new Vector2(upperPosition.x == 0 ? XMirrorOffset : 0, upperPosition.y);
    }

    private void MirrorLowerBalls()
    {
        var lowerPosition = lowerBalls.transform.position;
        lowerBalls.transform.position = new Vector2(lowerPosition.x == 0 ? -XMirrorOffset : 0, lowerPosition.y);
    }

    private IEnumerator ChangePlayerColor(float delayTime)
    {
        // Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);

        if (_spriteRenderer.color == Color.black)
        {
            _spriteRenderer.color = Color.white;
            gameObject.tag = "white";
        }
        else
        {
            _spriteRenderer.color = Color.black;
            gameObject.tag = "black";
        }
    }

    private static int GetRandomNumber()
    {
        return Random.Range(-5, 5);
    }
}