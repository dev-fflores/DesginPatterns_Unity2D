using UnityEngine;

namespace Ships
{
    public class LimitOutsideCameraAdapter : ICheckLimits
    {
        private readonly Transform _shipTransform;
        private readonly float _maxDistance;
        private readonly Vector3 _initialPosition;

        public LimitOutsideCameraAdapter(Transform shipTransform, float maxDistance)
        {
            _shipTransform = shipTransform;
            _maxDistance = maxDistance;
            _initialPosition = _shipTransform.position;
        }

        public void ClampFinalPosition()
        {
            var currentPosition = _shipTransform.position;
            var finalPosition = currentPosition;
            var distance = Mathf.Abs(currentPosition.x - _initialPosition.x);

            if (distance <= _maxDistance)
            {
                return;
            }

            if (currentPosition.x > _initialPosition.x)
            {
                finalPosition.x = _initialPosition.x + _maxDistance;
            }
            else
            {
                finalPosition.x = _initialPosition.x - _maxDistance;
            }
            /*
             if (distance > _maxDistance)
            {
                var direction = (_shipTransform.position - currentPosition).normalized;
                finalPosition = currentPosition + direction * _maxDistance;
            }
             */
            _shipTransform.position = finalPosition;
        }
    }
}