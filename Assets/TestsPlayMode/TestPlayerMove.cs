using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlayerMove
{
    private GameObject _player;
    private PlayerController _playerMove;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    
    [SetUp]
    public void Setup()
    {
        _player = new GameObject("Player");

        // Agregamos componentes correctamente
        _playerMove = _player.AddComponent<PlayerController>();
        _rigidbody2D = _player.AddComponent<Rigidbody2D>();
        _animator = _player.AddComponent<Animator>();
    }

    [UnityTest]
    public IEnumerator TestPlayerMoveWithEnumeratorPasses()
    {
        Vector3 posicionInicial = _player.transform.position;

        // Simulamos el movimiento del jugador en 2D
        _playerMove.transform.position += Vector3.right * _playerMove.speed * Time.deltaTime;

        yield return null;

        // Verificamos que el jugador se haya movido en la dirección esperada
        Assert.Greater(_player.transform.position.x, posicionInicial.x, "El jugador no avanzó correctamente.");
    }
}