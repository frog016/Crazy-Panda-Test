using System;
using System.Collections;
using UnityEngine;

namespace Shooting
{
    public class Cooldown
    {
        public bool IsReady { get; private set; }
        public float TimeToRestart { get; }

        private readonly MonoBehaviour _coroutineRunner;

        public Cooldown(float time, MonoBehaviour coroutineRunner)
        {
            TimeToRestart = time;
            IsReady = true;

            _coroutineRunner = coroutineRunner;
        }

        public void Restart()
        {
            if (IsReady == false)
                throw new InvalidOperationException("Can't restart cooldown when it is already restarting.");

            IsReady = false;
            _coroutineRunner.StartCoroutine(RestartCoroutine());
        }

        private IEnumerator RestartCoroutine()
        {
            yield return new WaitForSeconds(TimeToRestart);
            IsReady = true;
        }
    }
}