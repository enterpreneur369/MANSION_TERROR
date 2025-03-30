using UnityEngine;
using NUnit.Framework;

public class TestPlayer
{
    private GameObject _player;
    private PlayerController _playerMove;
    
    [SetUp]
    public void Setup()
    {
        _player = new GameObject();
        _playerMove = _player.AddComponent<PlayerController>();
    }

    [Test]
    public void SuccessInit()
    {
        Assert.AreEqual(4.0f, _playerMove.speed);
        Assert.AreEqual(false, _playerMove.playerTalking);
    }
}
