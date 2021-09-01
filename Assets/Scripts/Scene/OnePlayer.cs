using System;
using System.Collections;
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
        [SerializeField] private GameObject screenButton;
        [SerializeField] private GameObject upperButton;
        [SerializeField] private GameObject lowerButton;
        [SerializeField] private Text bestScoreText;
        [SerializeField] private Text scoreText;

        private Vector2 _speed;
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private int _score;
        private const float DelayTime = 0.05f;

        private void Start()
        {
            ChangeGameMode();
            
            Application.targetFrameRate = 120;
            
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

            _speed = new Vector2(0, Configs.Speed);
            _score = 0;

            UpdateBestScoreUI();
        }

        private void Update()
        {
            _rigidbody2D.velocity = _speed;
        }

        private void OnScreenClicked()
        {
            OnUpperClicked();
            OnLowerClicked();
        }

        private void OnUpperClicked()
        {
            AnimationTools.MirrorBalls(upperBalls);
        }

        private void OnLowerClicked()
        {
            AnimationTools.MirrorBalls(lowerBalls);
        }

        // Trigger on Player collide with Balls
        private void OnTriggerEnter2D(Collider2D collidedObject)
        {
            if (gameObject.tag.Equals(collidedObject.gameObject.tag))
            {
                Win();
            }
            else
            {
                GameOver();
            }
        }

        private void Win()
        {
            _speed = -_speed; // reverse moving direction

            // Change Player Color
            var random = GetRandomNumber();
            if (random > 0)
            {
                StartCoroutine(ChangePlayerColor(DelayTime));
            }

            IncreaseAndUpdateScore();
        }

        private void GameOver()
        {
            CheckAndUpdateBestScore();
            SceneLoader.LoadGameOver();
        }

        private void ChangeGameMode()
        {
            switch(Configs.GameMode)
            {
                case GameMode.OnePlayer:
                    screenButton.SetActive(true);
                    //upperButton.SetActive(false);
                    //lowerButton.SetActive(false);
                    break;

                case GameMode.TwoPlayer:
                    upperButton.SetActive(true);
                    lowerButton.SetActive(true);
                    break;

                default:
                    throw new ArgumentException();
            }
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

        private void IncreaseAndUpdateScore()
        {
            _score++;
            scoreText.text = _score.ToString();
        }

        private void CheckAndUpdateBestScore()
        {
            var bestScore = DataManager.GetScore();
            if (_score > bestScore)
            {
                DataManager.SaveScore(_score);
            }
        }

        private void UpdateBestScoreUI()
        {
            bestScoreText.text = $"Best Score: {DataManager.GetScore()}";
        }

        private static int GetRandomNumber()
        {
            return UnityEngine.Random.Range(-5, 5);
        }
    }
}