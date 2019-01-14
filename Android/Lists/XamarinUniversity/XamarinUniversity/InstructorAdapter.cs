using System.Collections.Generic;
using System.IO;
using System.Linq;
using Android.App;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace XamarinUniversity
{
    class InstructorAdapter : BaseAdapter<Instructor>, ISectionIndexer
    {
        List<Instructor> _instructors;
        private Object[] sectionHeaders;
        private Dictionary<int, int> positionForSectionMap;
        private Dictionary<int, int> sectionForPositionMap;
        public Java.Lang.Object[] GetSections()
        {
            return sectionHeaders;
        }

        public int GetPositionForSection(int section)
        {
            return positionForSectionMap[section];
        }

        public int GetSectionForPosition(int position)
        {
            return sectionForPositionMap[position];
        }
        public override Instructor this[int position] => _instructors.ElementAt(position);
        public InstructorAdapter(List<Instructor> instructors)
        {
            _instructors = instructors;
            sectionHeaders = SectionIndexerBuilder.BuildSectionHeaders(instructors);
            positionForSectionMap = SectionIndexerBuilder.BuildPositionForSectionMap(instructors);
            sectionForPositionMap = SectionIndexerBuilder.BuildSectionForPositionMap(instructors);
        }
        public override int Count => _instructors.Count;

        public override long GetItemId(int position)
        {
            return 1;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var view = convertView;
            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.InstructorRow, parent, false);


                var photo = view.FindViewById<ImageView>(Resource.Id.photoImageView);
                var name = view.FindViewById<TextView>(Resource.Id.nameTextView);
                var specialty = view.FindViewById<TextView>(Resource.Id.specialtyTextView);
                photo.SetImageDrawable(ImageAssetManager.Get(Application.Context, _instructors[position].ImageUrl));
                name.Text = _instructors[position].Name;
                specialty.Text = _instructors[position].Specialty;
                view.Tag = new ViewHolder() { Photo = photo, Name = name, Specialty = specialty };
            }

            var holder = (ViewHolder)view.Tag;

            holder.Photo.SetImageDrawable(ImageAssetManager.Get(parent.Context, _instructors[position].ImageUrl));
            holder.Name.Text = _instructors[position].Name;
            holder.Specialty.Text = _instructors[position].Specialty;

            return view;
        }
    }
}