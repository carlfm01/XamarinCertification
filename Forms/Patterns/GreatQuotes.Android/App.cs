using Android.App;
using System;
using Android.Runtime;
using GreatQuotes.Data;

namespace GreatQuotes
{
    [Application(Icon = "@drawable/icon", Label = "@string/app_name")]
    public class App : Application
    {
        private readonly SimpleContainer _container = new SimpleContainer();

        public App(IntPtr h, JniHandleOwnership jho) : base(h, jho)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            //QuoteLoaderFactory.Create = () => new QuoteLoader();
            ServiceLocator.Instance.Add<ITextToSpeech, TextToSpeechService>();
            _container.Register<IQuoteLoader, QuoteLoader>();
            _container.Create<QuoteManager>();
        }

        public static void Save() => QuoteManager.Instance.Save();
    }
}

