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
        private ListView mListView2;
        private ListView mListView3;
        private ArrayAdapter mLeftAdapter;
        private List<string> mLeftDataSet;
        private List<Menu> mItems2;
        private List<Menu> mItems3;
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
                    mListView2 = FindViewById<ListView>(Resource.Id.myListView2);
                    mItems2 = new List<Menu>();
                    mItems2.Add(new Menu() { item = "Personal (2 personas)", price = "$14.000" });
                    mItems2.Add(new Menu() { item = "Picada Martini", price = "$35.000" });
                    mItems2.Add(new Menu() { item = "Pizzetas", price = "$8.000" });
                    mItems2.Add(new Menu() { item = "Paninis", price = "$13.000" });
                    mItems2.Add(new Menu() { item = "Panini martini", price = "$14.000" });
                    mItems2.Add(new Menu() { item = "Burguer martini", price = "$13.000" });
                    mItems2.Add(new Menu() { item = "Bacon Burguer", price = "$14.000" });
                    mItems2.Add(new Menu() { item = "Perro martini", price = "$12.000" });
                    mItems2.Add(new Menu() { item = "Chori perro martini", price = "$12.000" });
                    mItems2.Add(new Menu() { item = "Mozarella Sticks", price = "$9.000" });

                    MyListViewAdapter adapter2 = new MyListViewAdapter(this,mItems2);
                    mListView2.Adapter = adapter2;
                    return true;
                case Resource.Id.action_fragment3:
                    ShowFragment(mfragment3);
                    mListView3 = FindViewById<ListView>(Resource.Id.myListView3);
                    mItems3 = new List<Menu>();
                    mItems3.Add(new Menu() { item = "Whisky Old Par\n500ml", price = "$129.000" });
                    mItems3.Add(new Menu() { item = "Whisky Old Par\n750ml", price = "$179.000" });
                    mItems3.Add(new Menu() { item = "Whisky Old Par Superior", price = "$25.0000" });
                    mItems3.Add(new Menu() { item = "Whisky Buchanas\n750ml", price = "$179.000" });
                    mItems3.Add(new Menu() { item = "Whisky Buchanas\n375ml", price = "$119.000" });
                    mItems3.Add(new Menu() { item = "Whisky Johnnie Walker Red\n750ml", price = "$109.000" });
                    mItems3.Add(new Menu() { item = "Whisky Johnnie Walker Black\n750ml", price = "$179.000" });
                    mItems3.Add(new Menu() { item = "Whisky Something Special\n375ml", price = "$79.000" });
                    mItems3.Add(new Menu() { item = "Whisky Something Special\n750ml", price = "$109.000" });
                    mItems3.Add(new Menu() { item = "Whisky Grants", price = "$109.000" });

                    mItems3.Add(new Menu() { item = "Vodka Absolut", price = "$119.000" });
                    mItems3.Add(new Menu() { item = "Vodka Absolut\n375 ml", price = "$79.000" });
                    mItems3.Add(new Menu() { item = "Vodka Smirnoff", price = "$11.0000" });
                    mItems3.Add(new Menu() { item = "Vodka Smirnoff\n375 ml", price = "$69.000" });

                    mItems3.Add(new Menu() { item = "Ginebra Gordons Gin\n750 ml", price = "$13.0000" });
                    mItems3.Add(new Menu() { item = "Ginebra Tanqueary\n750 ml", price = "$159.000" });

                    mItems3.Add(new Menu() { item = "Jose Cuervo\n750 ml", price = "$129.000" });
                    mItems3.Add(new Menu() { item = "Jose Cuervo\n375 ml", price = "$79.000" });

                    mItems3.Add(new Menu() { item = "Vinos\n750ml", price = "$69.000" });
                    mItems3.Add(new Menu() { item = "Copa de vino de la casa", price = "$1.0000" });
                    mItems3.Add(new Menu() { item = "Ron Medellin\n375 ml", price = "$55.000" });
                    mItems3.Add(new Menu() { item = "Ron Medellin\n750 ml", price = "$75.000" });
                    mItems3.Add(new Menu() { item = "Ron Medellin 8 años\n375 ml", price = "$69.000" });
                    mItems3.Add(new Menu() { item = "Ron Medellin 8 años\n750 ml", price = "$99.000" });
                    mItems3.Add(new Menu() { item = "Ron Viejo de Caldas\n375 ml", price = "$55.000" });
                    mItems3.Add(new Menu() { item = "Ron Viejo de Caldas\n750 ml", price = "$75.000" });
                    mItems3.Add(new Menu() { item = "Aguardiente antioqueño sin Azucar\n375 ml", price = "$45.000" });
                    mItems3.Add(new Menu() { item = "Aguardiente antioqueño sin Azucar\n750 ml", price = "$69.000" });
                    mItems3.Add(new Menu() { item = "Trago doble de Whisky", price = "$15.000" });
                    mItems3.Add(new Menu() { item = "Trago doble de Tequila", price = "$15.000" });
                    mItems3.Add(new Menu() { item = "Trago doble de Ron", price = "$15.000" });
                    mItems3.Add(new Menu() { item = "Trago doble de Vodka", price = "$15.000" });
                    mItems3.Add(new Menu() { item = "Smirnoff Ice\n355 ml", price = "$9.000" });

                    MyListViewAdapter adapter3 = new MyListViewAdapter(this, mItems3);
                    mListView3.Adapter = adapter3;
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

