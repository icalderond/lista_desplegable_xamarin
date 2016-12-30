using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace testListViewGroup
{
	public class ExpandibleAdapter:BaseExpandableListAdapter
	{
		public readonly Activity activity;
		public readonly List<Tarima> tarimaItems;
		public ExpandibleAdapter(Activity _activity, List<Tarima> _tarimas)
		{
			activity = _activity;
			tarimaItems = _tarimas;
		}

		public override int GroupCount
		{
			get
			{
				return tarimaItems.Count;
			}
		}

		public override bool HasStableIds
		{
			get
			{
				return true;
			}
		}

		public override long GetChildId(int groupPosition, int childPosition)
		{
			return childPosition;
		}

		public override int GetChildrenCount(int groupPosition)
		{
			var tarima = tarimaItems[groupPosition];
			return tarima.ProductItems.Count;
		}

		public override Java.Lang.Object GetGroup(int groupPosition)
		{
			return null;
		}

		public override long GetGroupId(int groupPosition)
		{
			return groupPosition;
		}

		public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
		{

            // Recycle a previous view if provided:
            var view = convertView;

			// If no recycled view, inflate a new view as a simple expandable list item 1:
			if (view == null)
			{
				var inflater = activity.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
				view = inflater.Inflate(Android.Resource.Layout.SimpleExpandableListItem1, null);
			}

			// Grab the produce object ("vegetables", "fruits", etc.) at the group position:
			var produce = tarimaItems[groupPosition];

			// Get the built-in first text view and insert the group name ("Vegetables", "Fruits", etc.):
			TextView textView = view.FindViewById<TextView>(Android.Resource.Id.Text1);
			textView.SetTextColor(Color.Magenta);
			textView.SetTypeface(Typeface.DefaultBold, TypefaceStyle.Bold);
			textView.Text = produce.NumTarima;

			return view;
		}
		public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
		{
			var view = convertView;

			if (view == null)
			{
				var inflater = activity.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
				view = inflater.Inflate(Android.Resource.Layout.SimpleExpandableListItem2, null);
			}

			var currentItem = tarimaItems[groupPosition].ProductItems[childPosition];
			string newId = currentItem.ProductName;
			string newValue = currentItem.CountProduct.ToString();

			TextView textView = view.FindViewById<TextView>(Android.Resource.Id.Text1);
			textView.Text = newId;

			textView = view.FindViewById<TextView>(Android.Resource.Id.Text2);
			textView.Text = newValue;

			return view;
		}


        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
		{
			return null;
		}

		public override bool IsChildSelectable(int groupPosition, int childPosition)
		{
			return true;
		}
	}
}
