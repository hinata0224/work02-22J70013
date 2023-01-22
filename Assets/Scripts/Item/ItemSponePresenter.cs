using UniRx;

namespace Item
{
    public class ItemSponePresenter
    {
        private static IReadSpone sponeModel;
        private static IReadItemSpone spone;

        public static void Inject(IReadSpone _sponeModel, IReadItemSpone _spone)
        {
            sponeModel= _sponeModel;
            spone = _spone;

            sponeModel.GetTimeEnd()
                .Subscribe(_ => spone.CreateItem(sponeModel.GetSponePos()));
        }

        public static void ChengeTimer(float time)
        {
            sponeModel.RestartTimer(time);

            sponeModel.GetTimeEnd()
                .Subscribe(_ => spone.CreateItem(sponeModel.GetSponePos()));
        }

        public static void TimerDispose()
        {
            sponeModel.Dispose();
        }
    }
}