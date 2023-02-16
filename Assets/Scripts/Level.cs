using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _gameOverScore;

    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private AudioController _audioController;
    [SerializeField] private AudioClip _gameOverAudioClip;
    [SerializeField] private AudioClip _gameAudioClip;

    private bool _isGameOver;

    public bool IsGameOver => _isGameOver;

    private void OnEnable()
    {
        _player.Dead += GameOver;
        _player.ScoreChanged += UpdateScoreText;
    }

    private void OnDisable()
    {
        _player.Dead -= GameOver;
        _player.ScoreChanged -= UpdateScoreText;
    }

    private void Start()
    {
        _audioController.PlayCurrentAudio(_gameAudioClip);
        _isGameOver = false;
        _scoreText.text = _player.Score.ToString();
    }

    private void UpdateScoreText(int score)
    {
        _scoreText.text = score.ToString();
        _gameOverScore.text = score.ToString();
    }

    private void GameOver(bool over)
    {
        _audioController.PlayCurrentAudio(_gameOverAudioClip);
        _gameOverPanel.SetActive(over);
        _isGameOver = over;
    }
}
