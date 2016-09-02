using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using System.Collections.Generic;
using SupportFragment = Android.Support.V4.App.Fragment;

namespace MartiniBar
{
    [Activity(Label = "MartiniBar", MainLauncher = true, Icon = "@drawable/icon", Theme ="@style/MyTheme")]
    public class MainActivity : AppCompatActivity
    {
        private SupportToolbar mToolbar;
        private MyActionBarDrawerToogle mDrawerToogle;
        private DrawerLayout mDrawerLayout;
        private ListView mLeftDrawer;
        private ArrayAdapter mLeftAdapter;
        private List<string> mLeftDataSet;
        private SupportFragment mCurrentFragment;
        private Fragments.Fragment1 mfragment1;
        private Fragments.Fragment2 mfragment2;
        private Fragments.Fragment3 mfragment3;
        private Fragments.Fragment4 mfragment4;
        private Stack<SupportFragment> mStackFragment;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
            mfragment1 = new Fragments.Fragment1();
            mfragment2 = new Fragments.Fragment2();
            mfragment3 = new Fragments.Fragment3();
            mfragment4 = new Fragments.Fragment4();
            mStackFragment = new Stack<SupportFragment>();
            SetSupportActionBar(mToolbar);

            var trans = SupportFragmentManager.BeginTransaction();
            trans.Add(Resource.Id.fragmentContainer, mfragment4, "fragment4");
            trans.Hide(mfragment4);
            trans.Add(Resource.Id.fragmentContainer, mfragment3, "fragment3");
            trans.Hide(mfragment3);
            trans.Add(Resource.Id.fragmentContainer, mfragment2, "fragment2");
            trans.Hide(mfragment2);
            trans.Add(Resource.Id.fragmentContainer, mfragment1, "fragment1");
            
            trans.Commit();

            mCurrentFragment = mfragment1;

            mLeftDataSet = new List<string>();
            mLeftDataSet.Add("Item 1");
            mLeftDataSet.Add("Item 2");
            mLeftAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mLeftDataSet);
            mLeftDrawer.Adapter = mLeftAdapter;
            mDrawerToogle = new MyActionBarDrawerToogle(
                this,
                mDrawerLayout,
                Resource.String.openDrawer,
                Resource.String.closeDrawer
                );

            mDrawerLayout.SetDrawerListener(mDrawerToogle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            mDrawerToogle.SyncState();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch(item.ItemId){
                case Android.Resource.Id.Home:
                    mDrawerToogle.OnOptionsItemSelected(item);
                    return true;
                case Resource.Id.action_fragment1:
                    ShowFragment(mfragment1);
                    return true;
                case Resource.Id.action_fragment2:
                    ShowFragment(mfragment2);
                    return true;
                case Resource.Id.action_fragment3:
                    ShowFragment(mfragment3);
                    return true;
                case Resource.Id.action_fragment4:
                    ShowFragment(mfragment4);
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
           /* mDrawerToogle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);*/
        }

        private void ShowFragment(SupportFragment fragment)
        {
            if (fragment.IsVisible)
            {
                return;
            }
            var trans = SupportFragmentManager.BeginTransaction();
            trans.SetCustomAnimations(Resource.Animation.slide_in, Resource.Animation.slide_out, Resource.Animation.slide_in, Resource.Animation.slide_out);
            trans.Hide(mCurrentFragment);
            trans.Show(fragment);
            trans.AddToBackStack(null);
            trans.Commit();

            mStackFragment.Push(mCurrentFragment);
            mCurrentFragment = fragment;
        }

        public override void OnBackPressed()
        {
            if (SupportFragmentManager.BackStackEntryCount > 0)
            {
                SupportFragmentManager.PopBackStack();
                mCurrentFragment = mStackFragment.Pop();
            }
            else
            {
                base.OnBackPressed();
            }
            
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.action_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

       
    }
}

