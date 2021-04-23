using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerBehaviour : MonoBehaviour
{
    [SerializeField]
    private static bool _gameOver = false;
    [SerializeField]
    private HealthBehaviour _playerHealth;
    [SerializeField]
    private GameObject _gameOverScreen;
    [SerializeField]
    private GameObject _rangedButton;
    [SerializeField]
    private GameObject _meleeButton;

    public static bool GameOver { get { return _gameOver; } }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    /// <summary>
    /// switches to melee mode
    /// </summary>
    public void MeleeMode()
    {
        _meleeButton.SetActive(false);
        _rangedButton.SetActive(true);
    }
    /// <summary>
    /// switches to range weapons
    /// </summary>
    public void RangedMode()
    {
        _meleeButton.SetActive(true);
        _rangedButton.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        _gameOver = _playerHealth.Health <= 0;
        _gameOverScreen.SetActive(_gameOver);
    }
}
