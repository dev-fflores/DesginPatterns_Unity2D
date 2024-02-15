using UnityEngine;

namespace Ships
{
    public class LimitInsideCameraAdapter : ICheckLimits
    {
        
        private readonly Camera _camera;
        private readonly Ship _ship;
        private readonly float _lowerLimit;
        private readonly float _upperLimit;

        public LimitInsideCameraAdapter(Ship ship, Camera camera)
        {
            _camera = camera;
            _ship = ship;
            _lowerLimit = 0.03f;
            _upperLimit = 0.97f;
        }

        public void ClampFinalPosition()
        {
            var viewportPoint = _camera.WorldToViewportPoint(_ship.transform.position);
            viewportPoint.x = Mathf.Clamp(viewportPoint.x, _lowerLimit, _upperLimit);
            viewportPoint.y = Mathf.Clamp(viewportPoint.y, _lowerLimit, _upperLimit);
            Debug.Log(_camera.ViewportToWorldPoint(viewportPoint));
            _ship.transform.position = _camera.ViewportToWorldPoint(viewportPoint);
        }
    }
}