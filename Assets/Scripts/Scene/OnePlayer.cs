using Data;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Utils;

namespace Scene
{
    public class OnePlayer : MonoBehaviour
    {
        [SerializeField] GameObject _leftBalls;
        [SerializeField] GameObject _rightBalls;
        [SerializeField] GameObject _screenButton;
        [SerializeField] GameObject _leftButton;
        [SerializeField] GameObject _rightButton;
        [SerializeField] GameObject _gameplayMenu;
        [SerializeField] GameObject _gameResultMenu;
        [SerializeField] TextMeshProUGUI _bestScoreText;
        [SerializeField] TextMeshProUGUI _scoreText;

        private Vector2 _speed;
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private int _score;
        private const float DelayTime = 0.05f;

        private void OnEnable()
        {
            ChangeGameMode();

            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

            _speed = new Vector2(Configs.Speed, 0);
            _score = 0;

            UpdateBestScoreUI();
        }

        private void Update()
        {
            _rigidbody2D.velocity = _speed;
        }

        private void OnScreenClicked()
        {
            OnRightClicked();
            OnLeftClicked();
        }

        private void OnRightClicked()
        {
            AnimationTools.MirrorBalls(_rightBalls);
        }

        private void OnLeftClicked()
        {
            AnimationTools.MirrorBalls(_leftBalls);
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
            UpdateCurrentScore();
            ResetGame();

            _gameResultMenu.SetActive(true);
            _gameplayMenu.SetActive(false);
        }

        private void ChangeGameMode()
        {
            switch (Configs.GameMode)
            {
                case GameMode.OnePlayer:
                    _screenButton.SetActive(true);
                    //upperButton.SetActive(false);
                    //lowerButton.SetActive(false);
                    break;

                case GameMode.TwoPlayer:
                    _rightButton.SetActive(true);
                    _leftButton.SetActive(true);
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
            _scoreText.text = _score.ToString();
        }

        private void CheckAndUpdateBestScore()
        {
            var bestScore = DataManager.GetBestScore();
            if (_score > bestScore)
            {
                DataManager.SaveBestScore(_score);
            }
        }

        private void UpdateCurrentScore()
        {
            DataManager.SaveCurrentScore(_score);
        }

        private void UpdateBestScoreUI()
        {
            _bestScoreText.text = $"Best Score: {DataManager.GetBestScore()}";
        }

        private void ResetGame()
        {
            _speed = Vector2.zero;
            transform.position = new Vector3(0, 0, transform.position.z);
        }

        private static int GetRandomNumber()
        {
            return UnityEngine.Random.Range(-5, 5);
        }
    }
}