using UnityEngine;

namespace Ships.CheckLimits
{
    public class LimitInsideCameraAdapter : ICheckLimits
    {
        
        private readonly Camera _camera;
        private readonly ShipMediator _shipMediator;
        private readonly float _lowerLimit;
        private readonly float _upperLimit;

        public LimitInsideCameraAdapter(ShipMediator shipMediator, Camera camera)
        {
            _camera = camera;
            _shipMediator = shipMediator;
            _lowerLimit = 0.03f;
            _upperLimit = 0.97f;
        }

        public void ClampFinalPosition()
        {
            var viewportPoint = _camera.WorldToViewportPoint(_shipMediator.transform.position);
            viewportPoint.x = Mathf.Clamp(viewportPoint.x, _lowerLimit, _upperLimit);
            viewportPoint.y = Mathf.Clamp(viewportPoint.y, _lowerLimit, _upperLimit);
            Debug.Log(_camera.ViewportToWorldPoint(viewportPoint));
            _shipMediator.transform.position = _camera.ViewportToWorldPoint(viewportPoint);
        }
    }
}