﻿using System.Collections;
using Data;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Scene
{
    public class OnePlayer : MonoBehaviour
    {
        [SerializeField] private GameObject upperBalls;
        [SerializeField] private GameObject lowerBalls;
        [SerializeField] private Text scoreText;

        private const float XMirrorOffset = 1.2f;
        private const float DelayTime = 0.05f;
        private float _speed;
        private int _score;

        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;

        // Start is called before the first frame update
        private void Start()
        {
            Application.targetFrameRate = 120;
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _speed = Configs.Speed;
            _score = 0;
        }

        // Update is called once per frame
        private void Update()
        {
            _rigidbody2D.velocity = new Vector2(0, _speed);

            if (Input.GetMouseButtonDown(0))
            {
                MirrorBalls();
                // StartCoroutine(MirrorBalls(DelayTime));
            }
        }

        private void OnTriggerEnter2D(Collider2D collidedObject)
        {
            if (gameObject.tag.Equals(collidedObject.gameObject.tag))
            {
                // OK
                _speed = -_speed; // reverse moving direction

                // Change Player Color
                var random = GetRandomNumber();
                if (random > 0)
                {
                    StartCoroutine(ChangePlayerColor(DelayTime));
                }

                IncreaseScore();

                // if (collidedObject.gameObject.transform.parent.name.Equals("Lower"))
                // {
                //     // AI: Change Upper Balls Color
                //     MatchUpperBallsWithPlayerColor();
                // }
            }
            else
            {
                // GameOver
                SceneLoader.LoadGameOver();
            }

            // switch (other.gameObject.name[0])
            // {
            //     case '0':
            //         // WhiteBallUpper
            //
            //         break;
            //
            //     case '1':
            //
            //         break;
            //
            //     case '2':
            //
            //         break;
            //
            //     case '3':
            //
            //         break;
            // }
        }

        private void MirrorBalls()
        {
            var upperPosition = upperBalls.transform.position;
            var lowerPosition = lowerBalls.transform.position;

            upperBalls.transform.position = new Vector2(upperPosition.x == 0 ? XMirrorOffset : 0, upperPosition.y);
            lowerBalls.transform.position = new Vector2(lowerPosition.x == 0 ? -XMirrorOffset : 0, lowerPosition.y);

            // if (position.y > 0)
            // {
            //     balls.tag = position.x == 0 ? "white" : "black";
            // }
            // else
            // {
            //     balls.tag = position.x == 0 ? "black" : "white";
            // }
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

        private void IncreaseScore()
        {
            _score++;
            scoreText.text = _score.ToString();
        }

        // private void MatchUpperBallsWithPlayerColor()
        // {
        //     if (_spriteRenderer.color == Color.black && upperBalls.tag.Equals("white") ||
        //         _spriteRenderer.color == Color.white && upperBalls.tag.Equals("black"))
        //     {
        //         MirrorBalls();
        //     }
        // }

        private static int GetRandomNumber()
        {
            return Random.Range(-5, 5);
        }
    }
}