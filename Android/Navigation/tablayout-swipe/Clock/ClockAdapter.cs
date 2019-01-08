using Android.Support.V4.App;
using Java.Lang;

namespace Clock
{
    public class ClockAdapter : FragmentPagerAdapter
    {
        ICharSequence[] titles;
        Fragment[] fragments;
        public override int Count => fragments.Length;
        public ClockAdapter(FragmentManager fm, Fragment[] fragments, ICharSequence[] titles) : base(fm)
        {
            this.fragments = fragments;
            this.titles = titles;
        }
        public override Fragment GetItem(int position) => fragments[position];

        public override ICharSequence GetPageTitleFormatted(int position) => titles[position];
    }
}