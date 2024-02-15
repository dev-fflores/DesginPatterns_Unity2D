namespace Patterns.Mediator
{
    public interface IVehicle
    {
        void BrakePressed();
        void BrakeReleased();
        void SteringWheelTurnLeftPressed();
        void SteringWheelTurnRightPressed();
        void AutopilotActivated();
        void AutopilotDeactivated();
        void ObstacleDetected();
    }
}