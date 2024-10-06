using Input;
using Ships.CheckLimits;
using Ships.Weapons;
using UnityEngine;

namespace Ships
{
    public class ShipMediator : MonoBehaviour, IShip
    {
        [SerializeField] private IInput _input;

        [SerializeField] private WeaponController _weaponController;
        [SerializeField] private MovementController _movementController;

        
        public void Configure(IInput input, ICheckLimits checkLimits)
        {
            _input = input;
            _movementController.Configure(this, checkLimits);
            _weaponController.Configure(this);
        }
        
        private void Update()
        {
            var direction = _input.GetDirection();
            _movementController.Move(direction);
            TryShoot();
        }
        
        public void TryShoot()
        {
            if (_input.IsFireActionPressed())
            {
                _weaponController.TryShoot();
            }
        }
    }
}