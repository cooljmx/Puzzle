using _project.Sources.Puzzle.Domain;
using UnityEngine;

namespace _project.Sources.Behaviors
{
    public class EntryPointBehavior : MonoBehaviour
    {
        public void Awake()
        {
        }

        public void Start()
        {
            var exampleService = Resolver.Instance.Resolve<IExampleService>();
        }

        public void Update()
        {
        }

        public void FixedUpdate()
        {
        }

        public void LateUpdate()
        {
        }

        public void OnDestroy()
        {
        }
    }
}