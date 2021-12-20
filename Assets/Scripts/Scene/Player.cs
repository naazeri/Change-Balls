using Data;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Scene
{
    public class Player : MonoBehaviour
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
        private const float ChangePlayerColorDelayTimeDelayTime = 0.05f;

        private void OnEnable()
        {
            //EnableTouchSupport(); // uncomment for android touch

            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

            _speed = new Vector2(Configs.Speed, 0);
            _score = 0;

            UpdateBestScoreUIFromDB();
        }

        private void FixedUpdate()
        {
            _rigidbody2D.velocity = _speed;
        }

        public void OnSpaceKeyPressed(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (Configs.GameMode == GameMode.OnePlayer)
                {
                    OnScreenClicked();
                }
                else
                {
                    OnLeftClicked();
                }
            }
        }

        public void OnEnterKeyPressed(InputAction.CallbackContext context)
        {
            // Enter key press
            if (context.performed)
            {
                if (Configs.GameMode == GameMode.OnePlayer)
                {
                    OnScreenClicked();
                }
                else
                {
                    OnRightClicked();
                }
            }
        }

        public void OnScreenClicked()
        {
            OnRightClicked();
            OnLeftClicked();
        }

        public void OnRightClicked()
        {
            AnimationTools.MirrorBalls(_rightBalls);
        }

        public void OnLeftClicked()
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
                StartCoroutine(ChangePlayerColor(ChangePlayerColorDelayTimeDelayTime));
            }

            IncreaseAndUpdateCurrentScoreUI();
        }

        private void GameOver()
        {
            SaveBestScore();
            SaveCurrentScore();
            ResetGame();

            var mainMenuClass = FindObjectOfType(typeof(MainMenu)) as MainMenu;
            mainMenuClass.UpdateGameResultScores();

            _gameResultMenu.SetActive(true);
            _gameplayMenu.SetActive(false);
        }

        private void EnableTouchSupport()
        {
            switch (Configs.GameMode)
            {
                case GameMode.OnePlayer:
                    _screenButton.SetActive(true);
                    _leftButton.SetActive(false);
                    _rightButton.SetActive(false);
                    break;

                case GameMode.TwoPlayer:
                    _screenButton.SetActive(false);
                    _leftButton.SetActive(true);
                    _rightButton.SetActive(true);
                    break;
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

        private void IncreaseAndUpdateCurrentScoreUI()
        {
            _score++;
            _scoreText.text = _score.ToString();
        }

        private void UpdateBestScoreUIFromDB()
        {
            _bestScoreText.text = $"Best Score: {DataManager.GetBestScore()}";
        }

        private void SaveBestScore()
        {
            var bestScore = DataManager.GetBestScore();

            if (_score > bestScore)
            {
                DataManager.SaveBestScore(_score);
            }
        }

        private void SaveCurrentScore()
        {
            DataManager.SaveCurrentScore(_score);
        }

        private void ResetGame()
        {
            _speed = Vector2.zero;
            transform.position = new Vector3(0, 0, transform.position.z);
            OnScreenClicked();
        }

        private static int GetRandomNumber()
        {
            return UnityEngine.Random.Range(-5, 5);
        }
    }
}