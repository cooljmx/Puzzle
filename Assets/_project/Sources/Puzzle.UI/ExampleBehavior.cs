using System;
using Assets.Sources.Puzzle.Domain;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Sources.Puzzle.UI
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class ExampleBehavior : MonoBehaviour
    {
        public IExampleService ExampleService { get; }

        private void Start()
        {
            Console.WriteLine();
        }

        private void Update()
        {
            Console.WriteLine();
        }
    }
}