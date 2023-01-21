
namespace Player_Input {
    public class PlayerInputPresener
    {
        private static PlayerMoveData moveData;

        public static void Inject(PlayerMoveData _data)
        {
            moveData = _data;
        }

        public static void ClickMove(int _check,bool _flag)
        {
            moveData.ClickMove(_check, _flag);
        }
    }
}