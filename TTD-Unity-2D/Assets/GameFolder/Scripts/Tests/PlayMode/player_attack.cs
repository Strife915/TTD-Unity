using System.Collections;
using NUnit.Framework;
using Unity.TDD.Abstracts.Controller;
using Unity.TDD.Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace TDDBeginner.Combats
{
    public class player_attack : MonoBehaviour
    {
        IPlayerController _playerController;
        IEnemyController _enemyController;

        [UnitySetUp]
        public IEnumerator SetUpAsyn()
        {
            yield return SceneManager.LoadSceneAsync("PlayerCombatTest");
            _enemyController = GameObject.FindObjectOfType<EnemyController>();
            _playerController = GameObject.FindObjectOfType<PlayerController>();
        }

        [UnityTest]
        public IEnumerator player_attack_enemy_one_time()
        {
            //Arrange


            int initialHealth = _enemyController.Health.CurrentHealth;

            //Act
            Vector3 enemyUpPosition = _enemyController.transform.position + (Vector3.up / 2);
            _playerController.transform.position = enemyUpPosition;

            //Assert
            yield return new WaitForSeconds(1f);
            Assert.AreNotEqual(initialHealth, _enemyController.Health.CurrentHealth);
        }

        [UnityTest]
        [TestCase(-1, 0, ExpectedResult = (IEnumerator)null)] //Left
        [TestCase(1f, 0f, ExpectedResult = (IEnumerator)null)] //Right
        [TestCase(0, -1, ExpectedResult = (IEnumerator)null)] //Bottom
        public IEnumerator player_attack_enemy_from_left_right_bottom_side(float x, float y)
        {
            //Arrange
            Vector3 attackPosition = new Vector3(x, y, 0);
            int initialHealth = _enemyController.Health.CurrentHealth;
            //Act
            Vector3 enemyUpPosition = _enemyController.transform.position + (attackPosition / 2);
            _playerController.transform.position = enemyUpPosition;

            yield return new WaitForSeconds(3f);
            //Assert
            Assert.AreEqual(initialHealth, _enemyController.Health.CurrentHealth);
        }
    }
}