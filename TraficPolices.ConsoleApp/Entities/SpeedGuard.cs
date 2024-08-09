using TraficPolices.ConsoleApp.Interfaces;

namespace TraficPolices.ConsoleApp.Entities
{
    public class SpeedGuard(IUi ui) : HasIdClass
    {
        public override int Id { get; set; }

        public Movement Guard()
        {
            return ui.GetMovement();
        }
    }
}