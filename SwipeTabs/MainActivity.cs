using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using System.Collections.Generic;
using System;

namespace SwipeTabs
{
	[Activity(Label = "Foo", MainLauncher = true, Icon = "@mipmap/icon", Theme="@style/MyMaterialTheme")]
	public class MainActivity : AppCompatActivity
	{
		private Android.Support.V7.Widget.Toolbar toolbar;
		private TabLayout tabLayout;
		private ViewPager viewPager;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);


			toolbar = (Android.Support.V7.Widget.Toolbar)FindViewById(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);

			SupportActionBar.SetDisplayHomeAsUpEnabled(false);

			viewPager = (ViewPager)FindViewById(Resource.Id.viewpager);
			SetupViewPager(viewPager);

			tabLayout = (TabLayout)FindViewById(Resource.Id.tabs);
			tabLayout.SetupWithViewPager(viewPager);


		}

		private void SetupViewPager(ViewPager viewPager)
		{
			ViewPagerAdapter adapter = new ViewPagerAdapter(SupportFragmentManager);
			adapter.AddFragment(new TestFragment(), "ONE");
			adapter.AddFragment(new TestFragment(), "TWO");
			 
			viewPager.Adapter = adapter;
		}
	}

	public class ViewPagerAdapter : FragmentPagerAdapter
	{

		private List<Android.Support.V4.App.Fragment> mFragmentList;
		private List<string> mFragmentTitleList;

		public ViewPagerAdapter(Android.Support.V4.App.FragmentManager manager) : base(manager)
		{
			mFragmentList = new List<Android.Support.V4.App.Fragment>();
			mFragmentTitleList = new List<string>();
		}

		public override int Count
		{
			get
			{
				return mFragmentList.Count;
			}
		}



		public void AddFragment(Android.Support.V4.App.Fragment fragment, string title)
		{
			mFragmentList.Add(fragment);
			mFragmentTitleList.Add(title);
		}

		public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
		{
			// https://forums.xamarin.com/discussion/37716/how-to-convert-net-string-to-java-lang-icharsequence
			return new Java.Lang.String(mFragmentTitleList[position]);
		}


	
		public string WurstgetPageTitle(int position)
		{
			return mFragmentTitleList[position];
		}

		public override Android.Support.V4.App.Fragment GetItem(int position)
		{
			return mFragmentList[position];
		}
	}
}


